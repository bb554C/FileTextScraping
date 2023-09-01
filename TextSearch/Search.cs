using System.Text;
using System.Text.RegularExpressions;
using TextSearch.Classes;

namespace TextSearch
{
    public partial class Search : Form
    {
        Dictionary<int, string> Results = new Dictionary<int, string>();
        Queue<string> FilesDir = new Queue<string>();
        ManualResetEvent ResetEvent = new ManualResetEvent(false);

        public int ResultsVauleMaxLineCount = 200;
        public int MaxLineCount = 5000;
        public int ThreadCounter;
        public int ProgressCounter;
        public int maxThread = 3;
        public string ResultsValue = "";
        public string SearchValues = "";
        public int DirCount;

        public Search()
        {
            InitializeComponent();
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            Thread runThread = new Thread(new ThreadStart(RunSearch));

            runThread.IsBackground = true;
            runThread.Start();
        }
        private void DisableAllControls()
        {
            Invoke((MethodInvoker)delegate
            {
                buttonBrowse.Enabled = false;
                buttonSearch.Enabled = false;
                textBoxPrefix.Enabled = false;
                textBoxSuffix.Enabled = false;
                textBoxSearch.ReadOnly = true;
                textBoxLineCount.Enabled = false;
                radioButtonPrefix.Enabled = false;
                radioButtonSuffix.Enabled = false;
            });
        }

        private void EnableAllControls()
        {
            Invoke((MethodInvoker)delegate
            {
                buttonBrowse.Enabled = true;
                buttonSearch.Enabled = true;
                textBoxLineCount.Enabled = true;
                textBoxSearch.ReadOnly = false;
                radioButtonPrefix.Enabled = true;
                radioButtonSuffix.Enabled = true;
                if (radioButtonPrefix.Checked)
                {
                    textBoxPrefix.Enabled = true;
                }
                else if (radioButtonSuffix.Checked)
                {
                    textBoxSuffix.Enabled = true;
                }
                if (checkBoxShutDown.Checked)
                {
                    Application.Exit();
                }
            });
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();

            if (folderDlg.ShowDialog() == DialogResult.OK)
            {
                textBoxDirectory.Text = folderDlg.SelectedPath;
            }
            if (textBoxDirectory.Text.Length > 0)
            {
                textBoxSearch.Enabled = true;
                buttonSearch.Enabled = true;
                GetFiles();
            }
        }

        private void RadioButtonPreFix_CheckedChanged(object sender, EventArgs e)
        {
            RadioClick();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioClick();
        }

        private void RadioClick()
        {
            if (radioButtonPrefix.Checked)
            {
                radioButtonSuffix.Checked = false;
                textBoxSuffix.Enabled = false;
                textBoxSuffix.Text = string.Empty;

                textBoxPrefix.Enabled = true;
                textBoxPrefix.Text = string.Empty;
                textBoxPrefix.Select();
            }
            else if (radioButtonSuffix.Checked)
            {
                radioButtonPrefix.Checked = false;
                textBoxPrefix.Enabled = false;
                textBoxPrefix.Text = string.Empty;

                textBoxSuffix.Enabled = true;
                textBoxSuffix.Text = string.Empty;
                textBoxSuffix.Select();
            }
        }

        private void ListBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedIndex >= 0)
            {
                textBoxResults.Text = Results[listBoxFiles.SelectedIndex];
            }

        }


        private void TextBoxPrefixSuffix_TextChanged(object sender, EventArgs e)
        {
            GetFiles();
        }

        private void GetFiles()
        {
            FilesDir.Clear();
            ResultsValue = "";
            DirCount = Utilities.GetFilesCount(textBoxDirectory.Text, textBoxPrefix.Text, textBoxSuffix.Text);
            FilesDir = Utilities.GetFiles(textBoxDirectory.Text, textBoxPrefix.Text, textBoxSuffix.Text, DirCount);

            foreach (string file in FilesDir)
            {
                Utilities.InsertNewTextLine(ref ResultsValue, "File Found : " + Utilities.GetFileNameOnly(textBoxDirectory.Text, file));
            }
            Utilities.InsertNewTextLine(ref ResultsValue, "FILE COUNT : " + DirCount);
            Utilities.InsertNewTextLine(ref ResultsValue, "THREADPOOL COUNT : " + ThreadPool.ThreadCount);
            UpdateResultsTextBox();
        }


        private void RunSearch()
        {
            ThreadPool.SetMinThreads(100, 100);
            UpdateResultsTextBox();
            DisableAllControls();
            ResultsValue = "";
            if (textBoxSearch.Text.Length > 0)
            {
                string currentDirectory = textBoxDirectory.Text;
                int counter = 0;

                string[] fileDir = FilesDir.ToArray();
                string[] searchValue = Regex.Split(textBoxSearch.Text, Environment.NewLine);
                string fileName = "";

                Utilities.RemoveOutputFiles(currentDirectory);
                GetFiles();

                SearchValues = "";
                ProgressCounter = 0;
                ResultsValue = "";
                Results.Clear();
                ThreadCounter = 0;
                ResultsValue = "";
                UpdateTextSearch();
                for (int i = 0; i < searchValue.Length; i++)
                {
                    if (searchValue[i] != "")
                    {
                        if (SearchValues == "")
                        {
                            SearchValues = searchValue[i];
                        }
                        else
                        {
                            SearchValues = SearchValues + "\r\n" + searchValue[i];
                        }
                        for (int j = (i + 1); j < searchValue.Length; j++)
                        {
                            if (searchValue[i].Equals(searchValue[j]))
                            {
                                Utilities.InsertNewTextLine(ref ResultsValue, "Duplicate Value Removed: [" + searchValue[j] + "]");
                                UpdateResultsTextBox();
                                searchValue[j] = "";
                            }
                        }
                    }
                    UpdateTextSearch();
                }
                searchValue = Regex.Split(textBoxSearch.Text, Environment.NewLine);
                int searchValueCount = searchValue.Length;
                int fileCount = DirCount;
                var tasks = new Task[fileCount];

                Invoke((MethodInvoker)delegate
                {
                    progressBarFileLoading.Maximum = (fileCount * searchValueCount) + fileCount;
                    textBoxResults.Clear();
                    listBoxFiles.Items.Clear();
                    listBoxFiles.Enabled = false;
                });

                Utilities.InsertNewTextLine(ref ResultsValue, "Loading Files");
                Utilities.InsertNewTextLine(ref ResultsValue, "PLEASE WAIT, PROGRAM MAY APPEAR UNRESPONSIVE");
                Utilities.InsertNewTextLine(ref ResultsValue, "Search Value Count: " + searchValue.Length.ToString());

                UpdateProgressBar();
                UpdateResultsTextBox();
                AddListBoxItem("HOME");

                for (int i = 0; i < searchValueCount; i++)
                {
                    Utilities.InsertNewTextLine(ref ResultsValue, "Search Value#" + (i + 1).ToString("000") + ": [" + searchValue[i] + "]");
                    UpdateResultsTextBox();
                }
                for (int i = 0; i < fileCount; i++)
                {
                    ResetEvent.Reset();
                    fileName = Utilities.GetFileNameOnly(currentDirectory, fileDir[i]);
                    ThreadCounter++;
                    tasks[counter] = Task.Run(() => LineRead(currentDirectory, fileDir[i], fileName, i + 1, searchValue));
                    AddListBoxItem(fileName);
                    Thread.Sleep(1000);
                    UpdateResultsTextBox();
                    UpdateProgressBar();
                    UpdateResultsTextBox();
                    counter++;
                    if (ThreadCounter >= maxThread)
                    {
                        ResetEvent.WaitOne();
                    }
                }
                while (ThreadCounter > 0)
                {
                    Task.WaitAny(tasks);
                    UpdateProgressBar();
                    UpdateResultsTextBox();
                }
                Results.Add(0, ResultsValue);
                Invoke((MethodInvoker)delegate
                {

                    listBoxFiles.Enabled = true;
                });
                UpdateStatusLabel("All Files Search Complete");
                Utilities.InsertNewTextLine(ref ResultsValue, "Search Complete");
                UpdateResultsTextBox();
                Array.Clear(searchValue);
                Array.Clear(fileDir);
            }
            else
            {
                MessageBox.Show("Search must not be empty", "SearchBox Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            EnableAllControls();
        }

        private void LineRead(string currentDirectory, string currentFile, string fileName, int fileCount, string[] searchValue)
        {
            string results = "";
            string tempLabel = "";
            var tasks = new Task[searchValue.Length];
            int taskSearchRemainingCount = 0;
            int lineCount = 0;
            int searchValuecounter = 0;
            tempLabel = "Loading lines from [" + fileName + "]";
            Utilities.InsertNewTextLine(ref ResultsValue, tempLabel);
            UpdateResultsTextBox();
            UpdateStatusLabel(tempLabel);

            string[] lineQueue = File.ReadAllLines(currentFile, Encoding.UTF8);

            UpdateStatusLabel("Searching in [" + fileName + "]");
            lineCount = lineQueue.Length;
            tempLabel = lineCount + " lines loaded from [" + fileName + "]";
            Utilities.InsertNewTextLine(ref ResultsValue, tempLabel);
            UpdateResultsTextBox();
            UpdateStatusLabel(tempLabel);
            UpdateProgressBar();
            ProgressCounter++;

            foreach (string search in searchValue)
            {
                if (search != "")
                {
                    Task.Run(() => UpdateResultsTextBox());
                    tasks[searchValuecounter] = Task.Run(() => LineSearch(currentDirectory, fileName, lineQueue, search, ref results, ref taskSearchRemainingCount));
                    Thread.Sleep(500);
                    searchValuecounter++;
                    taskSearchRemainingCount++;
                }
            }
            while (taskSearchRemainingCount > 0)
            {
                Task.WaitAny(tasks);
                UpdateResultsTextBox();
            }
            tempLabel = "All Search Complete in [" + fileName + "]";
            Utilities.InsertNewTextLine(ref ResultsValue, tempLabel);
            UpdateResultsTextBox();
            UpdateStatusLabel(tempLabel);
            Results.Add(fileCount, results);
            ThreadCounter--;
            Array.Clear(tasks);
            Array.Clear(lineQueue);
            ResetEvent.Set();
        }

        private void LineSearch(string currentDirectory, string fileName, string[] lineQueue, string searchValue, ref string results, ref int taskSearchRemainingCount)
        {
            Queue<string> writerQueue = new Queue<string>();
            int counterTop = 0;
            int counterBottom = 0;
            string tempLabel = "";
            bool foundFlag = false;
            string outFileName = currentDirectory + @"\FileSearchOutput_" + searchValue + "_" + fileName + ".txt";
            bool outputFlag = false;
            int instanceCounter = 0;

            for (int i = 0; i < lineQueue.Length; i++)
            {
                writerQueue.Enqueue("LINE# " + (i + 1).ToString("000000000") + " " + lineQueue[i]);
                counterBottom++;
                counterTop++;

                if (lineQueue[i].Contains(searchValue))
                {
                    foundFlag = true;
                    if (!outputFlag)
                    {
                        using (StreamWriter sw = File.AppendText(outFileName))
                        {
                            sw.WriteLine("Search Value: " + searchValue);
                            sw.WriteLine("");
                            sw.WriteLine("");
                        }
                    }
                    outputFlag = true;
                    foreach (string line in writerQueue)
                    {
                        using (StreamWriter sw = File.AppendText(outFileName))
                        {
                            sw.WriteLine(line);
                        }
                    }
                    UpdateStatusLabel("An instance of [" + searchValue + "] was found in [" + fileName + "]");
                    counterBottom = 0;
                    counterTop = 0;
                    writerQueue.Clear();
                    instanceCounter++;
                }

                if (!foundFlag && counterTop >= (MaxLineCount + 1))
                {
                    writerQueue.Dequeue();
                    counterTop--;
                }

                if (foundFlag && counterBottom > 0 && counterBottom <= MaxLineCount)
                {
                    using (StreamWriter sw = File.AppendText(outFileName))
                    {
                        sw.WriteLine(writerQueue.Peek());
                    }
                    writerQueue.Dequeue();
                    counterTop = 0;
                }
                if (foundFlag && counterBottom >= MaxLineCount && counterTop >= MaxLineCount)
                {
                    using (StreamWriter sw = File.AppendText(outFileName))
                    {
                        sw.WriteLine("");
                        sw.WriteLine("");
                        sw.WriteLine("");
                        sw.WriteLine("");
                        sw.WriteLine("");
                    }
                    foundFlag = false;
                    counterBottom = 0;
                }
            }
            if (outputFlag)
            {
                Utilities.InsertNewTextLine(ref results, "Results File Created at " + outFileName);
                Utilities.InsertNewTextLine(ref results, "Number of times [" + searchValue + "] is found in [" + fileName + "] = " + instanceCounter.ToString());
            }
            else
            {
                Utilities.InsertNewTextLine(ref results, "Search Value [" + searchValue + "] not found in [" + fileName + "]");
            }
            tempLabel = "Completed Search for [" + searchValue + "] in [" + fileName + "] - " + taskSearchRemainingCount.ToString() + " Search task still running.";
            Utilities.InsertNewTextLine(ref ResultsValue, tempLabel);
            UpdateResultsTextBox();
            UpdateStatusLabel(tempLabel);
            ProgressCounter++;
            taskSearchRemainingCount--;
            UpdateProgressBar();
            writerQueue.Clear();
        }
        private void UpdateResultsTextBox()
        {
            string[] tempStringArr = Regex.Split(ResultsValue, Environment.NewLine);
            if (tempStringArr.Length >= ResultsVauleMaxLineCount)
            {
                ResultsValue = "";
                for (int i = 1000; i < tempStringArr.Length; i++)
                {
                    tempStringArr[i] = "";
                }
                for (int i = 0; i < ResultsVauleMaxLineCount; i++)
                {
                    if (ResultsValue == "")
                    {
                        ResultsValue = tempStringArr[i];
                    }
                    else
                    {
                        ResultsValue = ResultsValue + "\r\n" + tempStringArr[i];
                    }
                }
            }
            Array.Clear(tempStringArr);
            Invoke((MethodInvoker)delegate
            {
                textBoxResults.Text = ResultsValue;
            });
        }
        private void AddListBoxItem(string value)
        {
            Invoke((MethodInvoker)delegate
            {
                listBoxFiles.Items.Add(value);
            });
        }
        private void UpdateStatusLabel(string value)
        {
            Invoke((MethodInvoker)delegate
            {
                labelLoadingFile.Text = value;
            });
        }
        private void UpdateProgressBar()
        {
            Invoke((MethodInvoker)delegate
            {
                progressBarFileLoading.Value = ProgressCounter;
            });
        }
        private void UpdateTextSearch()
        {
            Invoke((MethodInvoker)delegate
            {
                textBoxSearch.Text = SearchValues;
            });
        }

        private void textBoxLineCount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MaxLineCount = Convert.ToInt32(textBoxLineCount.Text);
                if (MaxLineCount > 5000)
                {
                    textBoxLineCount.Text = "5000";
                    MaxLineCount = 5000;
                }
                else
                {
                    MaxLineCount = Convert.ToInt32(textBoxLineCount.Text);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Line Number textbox. Must have an integer value", "ERROR! Line Number textbox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MaxLineCount = 5000;
                textBoxLineCount.Text = "5000";
            }

        }
    }
}