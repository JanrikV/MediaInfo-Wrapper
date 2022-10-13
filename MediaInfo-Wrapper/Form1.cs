using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaInfoLib;
using System.Net;
using System.Text.RegularExpressions;

namespace MediaInfoWrapper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            MediaInfoDataBox.Visible = false; // Set visible
            MediaInfoDataBox.WordWrap = false;
            MediaInfoDataBox.ScrollBars = RichTextBoxScrollBars.None;

        }

        private void AutoSizeTextBox(TextBox txt)
        {
            const int xMargin = 2;
            const int yMargin = 2;

            Size size = TextRenderer.MeasureText(txt.Text, txt.Font);
            txt.ClientSize = new Size(size.Width + xMargin, size.Height + yMargin);
        }

        private void TextHasChanged(object sender, EventArgs e)
        {

            AutoSizeTextBox(sender as TextBox);

        }

        private void OpenMediaFile_Click(object sender, EventArgs e)
        {

            // People save a lot of grap in desktop... so go there
            openFileDialog1.InitialDirectory = "C://Desktop";
            openFileDialog1.Title = "Select file";

            // These are enough?
            openFileDialog1.Filter = "(*.mkv; *.avi; *.mp4; *.h264; *.m4v; *.mov; *.mpg; *.mpeg; *.vob; *.wmv;)|*.mkv; *.avi; *.mp4; *.h264; *.m4v; *.mov; *.mpg; *.mpeg; *.vob; *.wmv;";
            openFileDialog1.FilterIndex = 1;

            // Set default value of SelectedFile (textbox)
            SelectedFile.Text = "Filename...";
            SelectedFile.Size = new System.Drawing.Size(283, 24);

            // Clear and hide MediaInfo Data box
            MediaInfoDataBox.Clear();
            MediaInfoDataBox.Visible = false;



            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Check if File exists
                    if (openFileDialog1.CheckFileExists)
                    {

                        string FileName = Path.GetFileName(openFileDialog1.FileName); // FileName
                        string FileNameWithoutExt = Path.GetFileNameWithoutExtension(openFileDialog1.FileName); // FileName Without Extension
                        string FilePath = Path.GetFullPath(openFileDialog1.FileName); // FullPath


                        SelectedFile.Clear(); // Clear SelectedFile box
                        SelectedFile.AppendText(FileName); // Add filename to the SelectedFile box

                        // Resize a SelectedFile (textbox) to fit
                        SelectedFile.TextChanged += TextHasChanged;
                        SelectedFile.Multiline = true;
                        SelectedFile.ScrollBars = ScrollBars.None;
                        AutoSizeTextBox(SelectedFile);

                        // Get MediaInfo data
                        MediaInfo MI = new MediaInfo();
                        MI.Open(FilePath);

                        // General
                        string container = MI.Get(StreamKind.General, 0, "Format");
                        string bitrate = MI.Get(StreamKind.General, 0, "BitRate/String");

                        string fileSize = MI.Get(StreamKind.General, 0, "FileSize/String");

                        // subs list
                        string subList = "";
                        string subs = "";
                        string pattern = "";
                        string replace = "";


                        if (!string.IsNullOrEmpty(MI.Get(StreamKind.Text, 0, "Language/String")))
                        {

                            int subtitlesInt = Int32.Parse(MI.Get(StreamKind.General, 0, "TextCount"));

                            for (int c = 0; c < subtitlesInt; c++)
                            {
                                subList += MI.Get(StreamKind.Text, c, "Language/String3").UpperCaseFirstCharacter() + ", ";
                            }

                            subs = subList.TrimEnd(',', ' ');

                            if (subs.Contains("Nob") == true)
                            {
                                pattern = @"\bNob\b";
                                replace = "Nor";
                                subs = Regex.Replace(subs, pattern, replace);
                            }
                        }
                        else
                        {
                            subs = "N/A";
                        }


                        // Video
                        string vBitRate = MI.Get(StreamKind.Video, 0, "BitRate/String");
                        string vWidth = MI.Get(StreamKind.Video, 0, "Width");
                        string vHeight = MI.Get(StreamKind.Video, 0, "Height");
                        string duration = MI.Get(0, 0, "Duration/String1").Substring(0, MI.Get(0, 0, "Duration/String3").LastIndexOf("."));
                        string fps = MI.Get(StreamKind.Video, 0, "FrameRate/String");
                        string fpst = Regex.Replace(fps, @"\([^()]*\)", string.Empty).ToLower();
                        string fpsTrimmed = Regex.Replace(fpst, @"\s+", " ");


                        // Audio
                        string audio = MI.Get(StreamKind.Audio, 0, "Format");
                        string aBitRate = MI.Get(StreamKind.Audio, 0, "BitRate/String");
                        string channel = MI.Get(StreamKind.Audio, 0, "Channel(s)");
                        string lang = MI.Get(StreamKind.Audio, 0, "Language/String1");
                        string audioCount = MI.Get(StreamKind.General, 0, "TextCount");

                        // Check video bitrate
                        if (string.IsNullOrEmpty(vBitRate))
                        {
                            MessageBox.Show("Video bitrate not found");
                            return;
                        }


                        // Check audio bitrate
                        if (string.IsNullOrEmpty(aBitRate))
                        {
                            MessageBox.Show("Audio bitrate not found");
                            return;
                        }


                        string display = "";

                        display += "\r\n" + FileNameWithoutExt + "\r\n";

                        display += "\r\n";

                        display += "Duration: " + duration + "\r\n";
                        display += "Resolution: " + vWidth + "x" + vHeight + "\r\n";
                        display += "Video bitrate: " + vBitRate + "\r\n";
                        display += "FPS: " + fps + "\r\n";
                        display += "Audio: " + lang + ", " + audio + ", " + aBitRate + "\r\n";
                        display += "Subtitles: " + subs + "\r\n";



                        MediaInfoDataBox.Clear(); // Clear
                        MediaInfoDataBox.Visible = true; // Set visible
                        MediaInfoDataBox.WordWrap = false;
                        MediaInfoDataBox.ScrollBars = RichTextBoxScrollBars.Both;
                        MediaInfoDataBox.AppendText(display); // Add parsed MI data to the box

                        MI.Close();

                    }
                }
                else
                {
                    MessageBox.Show("Select file");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



    }
}