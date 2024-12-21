using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SpaceDefender
{
    partial class FormMain
    {
        PrivateFontCollection privateFonts = new PrivateFontCollection();

        /// <summary>
        /// A very non-elegant workaround to get the path to the .ttf file for the font.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        private string GetFontFilePath()
        {
            // Get the current directory
            string currentDirectory = Environment.CurrentDirectory;

            // Navigate to the Resources folder relative to the current directory
            string relativePath = Path.Combine("..", "..", "..", "Resources", "PressStart2P-vaV7.ttf");

            // Combine the current directory with the relative path
            string fontFilePath = Path.GetFullPath(Path.Combine(currentDirectory, relativePath));

            // Check if the file exists
            if (!File.Exists(fontFilePath))
            {
                throw new FileNotFoundException($"Font file not found at {fontFilePath}");
            }

            return fontFilePath;
        }

        /// <summary>
        /// Loads the custom font.
        /// </summary>
        private void LoadFontFromFile()
        {
            string fontFilePath = GetFontFilePath();

            if (File.Exists(fontFilePath))
            {
                privateFonts.AddFontFile(fontFilePath);
            }
            else
            {
                MessageBox.Show($"Font file not found: {fontFilePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            exitTableLayoutPanelExiting = new GlobalUtilsGUI.DoubleBufferedTableLayoutPanel();
            exitLabelExiting = new Label();
            exitTableLayoutPanelMain = new GlobalUtilsGUI.DoubleBufferedTableLayoutPanel();
            exitLabelConfirm = new Label();
            exitTableLayoutPanelButtons = new GlobalUtilsGUI.DoubleBufferedTableLayoutPanel();
            exitButtonYes = new Button();
            exitButtonNo = new Button();
            mainTableLayoutPanelMain = new GlobalUtilsGUI.DoubleBufferedTableLayoutPanel();
            mainButtonAudio = new Button();
            mainLabelTitle = new Label();
            mainButtonPlay = new Button();
            mainButtonTutorial = new Button();
            mainButtonExit = new Button();
            tutorialTableLayoutPanelMain = new GlobalUtilsGUI.DoubleBufferedTableLayoutPanel();
            tutorialTableLayoutPanelContents = new GlobalUtilsGUI.DoubleBufferedTableLayoutPanel();
            tutorialRichTextBoxTutorial = new RichTextBox();
            tutorialLabelHeader = new Label();
            tutorialButtonBack = new Button();
            audioTableLayoutPanelMain = new GlobalUtilsGUI.DoubleBufferedTableLayoutPanel();
            audioLabelHeader = new Label();
            audioButtonBack = new Button();
            audioTableLayoutPanelContents = new GlobalUtilsGUI.DoubleBufferedTableLayoutPanel();
            audioLabelVolume = new Label();
            audioButtonMuteSfx = new Button();
            audioLabelSfxVolume = new Label();
            playTableLayoutPanelMain = new GlobalUtilsGUI.DoubleBufferedTableLayoutPanel();
            playButtonBack = new Button();
            playLabelHeader = new Label();
            playTableLayoutPanelContents = new GlobalUtilsGUI.DoubleBufferedTableLayoutPanel();
            playButtonEasy = new Button();
            playLabelChoose = new Label();
            playButtonMedium = new Button();
            playTableLayoutPanelComponentsCustom = new GlobalUtilsGUI.DoubleBufferedTableLayoutPanel();
            playLabelCustom = new Label();
            playLabelWaves = new Label();
            playTextBoxWaveInput = new TextBox();
            playButtonStart = new Button();
            playLabelWaveError = new Label();
            playButtonHard = new Button();
            startingTableLayoutPanelMain = new GlobalUtilsGUI.DoubleBufferedTableLayoutPanel();
            startingLabelStarting = new Label();
            gameButtonMenu = new Button();
            gameLabelWave = new Label();
            pausedTableLayoutPanelMain = new GlobalUtilsGUI.DoubleBufferedTableLayoutPanel();
            pausedLabelPaused = new Label();
            pausedButtonReturn = new Button();
            pausedButtonExit = new Button();
            gamePanelMain = new GlobalUtilsGUI.DoubleBufferedPanel();
            gameLabelStart = new Label();
            lostTableLayoutPanelMain = new TableLayoutPanel();
            lostLabelLost = new Label();
            lostButtonRestart = new Button();
            lostButtonMainMenu = new Button();
            wonTableLayoutPanelMain = new TableLayoutPanel();
            wonLabelWon = new Label();
            wonButtonMainMenu = new Button();
            exitTableLayoutPanelExiting.SuspendLayout();
            exitTableLayoutPanelMain.SuspendLayout();
            exitTableLayoutPanelButtons.SuspendLayout();
            mainTableLayoutPanelMain.SuspendLayout();
            tutorialTableLayoutPanelMain.SuspendLayout();
            tutorialTableLayoutPanelContents.SuspendLayout();
            audioTableLayoutPanelMain.SuspendLayout();
            audioTableLayoutPanelContents.SuspendLayout();
            playTableLayoutPanelMain.SuspendLayout();
            playTableLayoutPanelContents.SuspendLayout();
            playTableLayoutPanelComponentsCustom.SuspendLayout();
            startingTableLayoutPanelMain.SuspendLayout();
            pausedTableLayoutPanelMain.SuspendLayout();
            gamePanelMain.SuspendLayout();
            lostTableLayoutPanelMain.SuspendLayout();
            wonTableLayoutPanelMain.SuspendLayout();
            SuspendLayout();
            // 
            // exitTableLayoutPanelExiting
            // 
            exitTableLayoutPanelExiting.BackColor = Color.Black;
            exitTableLayoutPanelExiting.BackgroundImage = Properties.Resources.backgroundMainMenu;
            exitTableLayoutPanelExiting.ColumnCount = 1;
            exitTableLayoutPanelExiting.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            exitTableLayoutPanelExiting.Controls.Add(exitLabelExiting, 0, 1);
            exitTableLayoutPanelExiting.Dock = DockStyle.Fill;
            exitTableLayoutPanelExiting.Location = new Point(0, 0);
            exitTableLayoutPanelExiting.Name = "exitTableLayoutPanelExiting";
            exitTableLayoutPanelExiting.RowCount = 3;
            exitTableLayoutPanelExiting.RowStyles.Add(new RowStyle(SizeType.Percent, 20.8907242F));
            exitTableLayoutPanelExiting.RowStyles.Add(new RowStyle(SizeType.Percent, 41.50597F));
            exitTableLayoutPanelExiting.RowStyles.Add(new RowStyle(SizeType.Percent, 37.6033058F));
            exitTableLayoutPanelExiting.Size = new Size(1422, 763);
            exitTableLayoutPanelExiting.TabIndex = 7;
            exitTableLayoutPanelExiting.Visible = false;
            exitTableLayoutPanelExiting.VisibleChanged += ExitTableLayoutPanelExiting_VisibleChanged;
            // 
            // exitLabelExiting
            // 
            exitLabelExiting.Anchor = AnchorStyles.None;
            exitLabelExiting.AutoSize = true;
            exitLabelExiting.BackColor = Color.Transparent;
            exitLabelExiting.Font = new Font(privateFonts.Families[0], 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitLabelExiting.ForeColor = Color.RoyalBlue;
            exitLabelExiting.Location = new Point(477, 297);
            exitLabelExiting.Name = "exitLabelExiting";
            exitLabelExiting.Size = new Size(468, 40);
            exitLabelExiting.TabIndex = 0;
            exitLabelExiting.Text = "Goodbye! :)";
            // 
            // exitTableLayoutPanelMain
            // 
            exitTableLayoutPanelMain.BackColor = Color.Black;
            exitTableLayoutPanelMain.BackgroundImage = Properties.Resources.backgroundInnerMenu;
            exitTableLayoutPanelMain.ColumnCount = 1;
            exitTableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            exitTableLayoutPanelMain.Controls.Add(exitLabelConfirm, 0, 1);
            exitTableLayoutPanelMain.Controls.Add(exitTableLayoutPanelButtons, 0, 2);
            exitTableLayoutPanelMain.Dock = DockStyle.Fill;
            exitTableLayoutPanelMain.Location = new Point(0, 0);
            exitTableLayoutPanelMain.Name = "exitTableLayoutPanelMain";
            exitTableLayoutPanelMain.RowCount = 4;
            exitTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 20.3415432F));
            exitTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 31.0368366F));
            exitTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 24.1397629F));
            exitTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 24.4818573F));
            exitTableLayoutPanelMain.Size = new Size(1422, 763);
            exitTableLayoutPanelMain.TabIndex = 6;
            exitTableLayoutPanelMain.Visible = false;
            exitTableLayoutPanelMain.VisibleChanged += ExitTableLayoutPanelMain_VisibleChanged;
            // 
            // exitLabelConfirm
            // 
            exitLabelConfirm.Anchor = AnchorStyles.None;
            exitLabelConfirm.AutoSize = true;
            exitLabelConfirm.BackColor = Color.Transparent;
            exitLabelConfirm.Font = new Font(privateFonts.Families[0], 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitLabelConfirm.ForeColor = Color.RoyalBlue;
            exitLabelConfirm.Location = new Point(87, 253);
            exitLabelConfirm.Name = "exitLabelConfirm";
            exitLabelConfirm.Size = new Size(1247, 40);
            exitLabelConfirm.TabIndex = 0;
            exitLabelConfirm.Text = "Are you sure you wish to exit?";
            // 
            // exitTableLayoutPanelButtons
            // 
            exitTableLayoutPanelButtons.BackColor = Color.Transparent;
            exitTableLayoutPanelButtons.ColumnCount = 4;
            exitTableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            exitTableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            exitTableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            exitTableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            exitTableLayoutPanelButtons.Controls.Add(exitButtonYes, 1, 0);
            exitTableLayoutPanelButtons.Controls.Add(exitButtonNo, 2, 0);
            exitTableLayoutPanelButtons.Dock = DockStyle.Fill;
            exitTableLayoutPanelButtons.Location = new Point(3, 394);
            exitTableLayoutPanelButtons.Name = "exitTableLayoutPanelButtons";
            exitTableLayoutPanelButtons.RowCount = 1;
            exitTableLayoutPanelButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            exitTableLayoutPanelButtons.Size = new Size(1416, 178);
            exitTableLayoutPanelButtons.TabIndex = 1;
            // 
            // exitButtonYes
            // 
            exitButtonYes.Anchor = AnchorStyles.None;
            exitButtonYes.BackColor = Color.RoyalBlue;
            exitButtonYes.Font = new Font(privateFonts.Families[0], 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitButtonYes.Location = new Point(322, 41);
            exitButtonYes.Name = "exitButtonYes";
            exitButtonYes.Size = new Size(275, 95);
            exitButtonYes.TabIndex = 0;
            exitButtonYes.Text = "Yes";
            exitButtonYes.UseVisualStyleBackColor = false;
            exitButtonYes.Click += ExitButtonYes_Click;
            exitButtonYes.MouseEnter += ExitButtonYes_MouseEnter;
            exitButtonYes.MouseLeave += ExitButtonYes_MouseLeave;
            // 
            // exitButtonNo
            // 
            exitButtonNo.Anchor = AnchorStyles.None;
            exitButtonNo.BackColor = Color.RoyalBlue;
            exitButtonNo.Font = new Font(privateFonts.Families[0], 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitButtonNo.Location = new Point(817, 41);
            exitButtonNo.Name = "exitButtonNo";
            exitButtonNo.Size = new Size(275, 95);
            exitButtonNo.TabIndex = 1;
            exitButtonNo.Text = "No";
            exitButtonNo.UseVisualStyleBackColor = false;
            exitButtonNo.Click += ExitButtonNo_Click;
            exitButtonNo.MouseEnter += ExitButtonNo_MouseEnter;
            exitButtonNo.MouseLeave += ExitButtonNo_MouseLeave;
            // 
            // mainTableLayoutPanelMain
            // 
            mainTableLayoutPanelMain.BackColor = Color.Black;
            mainTableLayoutPanelMain.BackgroundImage = Properties.Resources.backgroundMainMenu;
            mainTableLayoutPanelMain.ColumnCount = 1;
            mainTableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainTableLayoutPanelMain.Controls.Add(mainButtonAudio, 0, 3);
            mainTableLayoutPanelMain.Controls.Add(mainLabelTitle, 0, 0);
            mainTableLayoutPanelMain.Controls.Add(mainButtonPlay, 0, 1);
            mainTableLayoutPanelMain.Controls.Add(mainButtonTutorial, 0, 2);
            mainTableLayoutPanelMain.Controls.Add(mainButtonExit, 0, 4);
            mainTableLayoutPanelMain.Dock = DockStyle.Fill;
            mainTableLayoutPanelMain.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            mainTableLayoutPanelMain.Location = new Point(0, 0);
            mainTableLayoutPanelMain.Margin = new Padding(6, 2, 6, 2);
            mainTableLayoutPanelMain.Name = "mainTableLayoutPanelMain";
            mainTableLayoutPanelMain.RowCount = 6;
            mainTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 38.07636F));
            mainTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 15.4809122F));
            mainTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 15.4809074F));
            mainTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 15.4809074F));
            mainTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 15.4809074F));
            mainTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            mainTableLayoutPanelMain.Size = new Size(1422, 763);
            mainTableLayoutPanelMain.TabIndex = 5;
            mainTableLayoutPanelMain.VisibleChanged += MainTableLayoutPanelMain_VisibleChanged;
            // 
            // mainButtonAudio
            // 
            mainButtonAudio.Anchor = AnchorStyles.None;
            mainButtonAudio.BackColor = Color.RoyalBlue;
            mainButtonAudio.Font = new Font(privateFonts.Families[0], 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mainButtonAudio.Location = new Point(411, 519);
            mainButtonAudio.Margin = new Padding(6, 2, 6, 2);
            mainButtonAudio.Name = "mainButtonAudio";
            mainButtonAudio.Size = new Size(600, 100);
            mainButtonAudio.TabIndex = 3;
            mainButtonAudio.Text = "Audio";
            mainButtonAudio.UseVisualStyleBackColor = false;
            mainButtonAudio.Click += MainButtonAudio_Click;
            mainButtonAudio.MouseEnter += MainButtonAudio_MouseEnter;
            mainButtonAudio.MouseLeave += MainButtonAudio_MouseLeave;
            // 
            // mainLabelTitle
            // 
            mainLabelTitle.Anchor = AnchorStyles.None;
            mainLabelTitle.AutoSize = true;
            mainLabelTitle.BackColor = Color.Transparent;
            mainLabelTitle.Font = new Font(privateFonts.Families[0], 46.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mainLabelTitle.ForeColor = Color.RoyalBlue;
            mainLabelTitle.Location = new Point(148, 102);
            mainLabelTitle.Margin = new Padding(6, 0, 6, 0);
            mainLabelTitle.Name = "mainLabelTitle";
            mainLabelTitle.Size = new Size(1125, 77);
            mainLabelTitle.TabIndex = 1;
            mainLabelTitle.Text = "Space Defender";
            // 
            // mainButtonPlay
            // 
            mainButtonPlay.Anchor = AnchorStyles.None;
            mainButtonPlay.BackColor = Color.RoyalBlue;
            mainButtonPlay.Font = new Font(privateFonts.Families[0], 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mainButtonPlay.ForeColor = Color.Black;
            mainButtonPlay.Location = new Point(411, 289);
            mainButtonPlay.Margin = new Padding(6, 2, 6, 2);
            mainButtonPlay.Name = "mainButtonPlay";
            mainButtonPlay.Size = new Size(600, 100);
            mainButtonPlay.TabIndex = 0;
            mainButtonPlay.Text = "Play";
            mainButtonPlay.UseVisualStyleBackColor = false;
            mainButtonPlay.Click += MainButtonPlay_Click;
            mainButtonPlay.MouseEnter += MainButtonPlay_MouseEnter;
            mainButtonPlay.MouseLeave += MainButtonPlay_MouseLeave;
            // 
            // mainButtonTutorial
            // 
            mainButtonTutorial.Anchor = AnchorStyles.None;
            mainButtonTutorial.BackColor = Color.RoyalBlue;
            mainButtonTutorial.Font = new Font(privateFonts.Families[0], 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mainButtonTutorial.Location = new Point(411, 404);
            mainButtonTutorial.Margin = new Padding(6, 2, 6, 2);
            mainButtonTutorial.Name = "mainButtonTutorial";
            mainButtonTutorial.Size = new Size(600, 100);
            mainButtonTutorial.TabIndex = 2;
            mainButtonTutorial.Text = "Tutorial";
            mainButtonTutorial.UseVisualStyleBackColor = false;
            mainButtonTutorial.Click += MainButtonTutorial_Click;
            mainButtonTutorial.MouseEnter += MainButtonTutorial_MouseEnter;
            mainButtonTutorial.MouseLeave += MainButtonTutorial_MouseLeave;
            // 
            // mainButtonExit
            // 
            mainButtonExit.Anchor = AnchorStyles.None;
            mainButtonExit.BackColor = Color.RoyalBlue;
            mainButtonExit.Font = new Font(privateFonts.Families[0], 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mainButtonExit.Location = new Point(411, 634);
            mainButtonExit.Margin = new Padding(6, 2, 6, 2);
            mainButtonExit.Name = "mainButtonExit";
            mainButtonExit.Size = new Size(600, 100);
            mainButtonExit.TabIndex = 4;
            mainButtonExit.Text = "Exit";
            mainButtonExit.UseVisualStyleBackColor = false;
            mainButtonExit.Click += MainButtonExit_Click;
            mainButtonExit.MouseEnter += MainButtonExit_MouseEnter;
            mainButtonExit.MouseLeave += MainButtonExit_MouseLeave;
            // 
            // tutorialTableLayoutPanelMain
            // 
            tutorialTableLayoutPanelMain.BackColor = Color.Black;
            tutorialTableLayoutPanelMain.BackgroundImage = Properties.Resources.backgroundInnerMenu;
            tutorialTableLayoutPanelMain.ColumnCount = 1;
            tutorialTableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tutorialTableLayoutPanelMain.Controls.Add(tutorialTableLayoutPanelContents, 0, 1);
            tutorialTableLayoutPanelMain.Controls.Add(tutorialLabelHeader, 0, 0);
            tutorialTableLayoutPanelMain.Controls.Add(tutorialButtonBack, 0, 2);
            tutorialTableLayoutPanelMain.Dock = DockStyle.Fill;
            tutorialTableLayoutPanelMain.Location = new Point(0, 0);
            tutorialTableLayoutPanelMain.Name = "tutorialTableLayoutPanelMain";
            tutorialTableLayoutPanelMain.RowCount = 3;
            tutorialTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 16.2223015F));
            tutorialTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 61.45582F));
            tutorialTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 22.3218861F));
            tutorialTableLayoutPanelMain.Size = new Size(1422, 763);
            tutorialTableLayoutPanelMain.TabIndex = 8;
            tutorialTableLayoutPanelMain.Visible = false;
            // 
            // tutorialTableLayoutPanelContents
            // 
            tutorialTableLayoutPanelContents.BackColor = Color.Transparent;
            tutorialTableLayoutPanelContents.ColumnCount = 3;
            tutorialTableLayoutPanelContents.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3.908148F));
            tutorialTableLayoutPanelContents.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 92.1837F));
            tutorialTableLayoutPanelContents.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3.90814734F));
            tutorialTableLayoutPanelContents.Controls.Add(tutorialRichTextBoxTutorial, 1, 1);
            tutorialTableLayoutPanelContents.Dock = DockStyle.Fill;
            tutorialTableLayoutPanelContents.Location = new Point(3, 126);
            tutorialTableLayoutPanelContents.Name = "tutorialTableLayoutPanelContents";
            tutorialTableLayoutPanelContents.RowCount = 3;
            tutorialTableLayoutPanelContents.RowStyles.Add(new RowStyle(SizeType.Percent, 25.2613239F));
            tutorialTableLayoutPanelContents.RowStyles.Add(new RowStyle(SizeType.Percent, 49.4773521F));
            tutorialTableLayoutPanelContents.RowStyles.Add(new RowStyle(SizeType.Percent, 25.2613239F));
            tutorialTableLayoutPanelContents.Size = new Size(1416, 462);
            tutorialTableLayoutPanelContents.TabIndex = 2;
            // 
            // tutorialRichTextBoxTutorial
            // 
            tutorialRichTextBoxTutorial.BackColor = Color.Black;
            tutorialRichTextBoxTutorial.Dock = DockStyle.Fill;
            tutorialRichTextBoxTutorial.Font = new Font(privateFonts.Families[0], 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tutorialRichTextBoxTutorial.ForeColor = Color.RoyalBlue;
            tutorialRichTextBoxTutorial.Location = new Point(58, 119);
            tutorialRichTextBoxTutorial.Name = "tutorialRichTextBoxTutorial";
            tutorialRichTextBoxTutorial.Size = new Size(1299, 222);
            tutorialRichTextBoxTutorial.TabIndex = 0;
            tutorialRichTextBoxTutorial.Text = "Defend your planet from wave after wave of alien attacks! Each wave gets harder, and you'll face unique challenges.\n\nControls\nMove: Use A/D or <-/-> keys.\nShoot: Click the Left Mouse Button to fire.";
            // 
            // tutorialLabelHeader
            // 
            tutorialLabelHeader.Anchor = AnchorStyles.None;
            tutorialLabelHeader.AutoSize = true;
            tutorialLabelHeader.BackColor = Color.Transparent;
            tutorialLabelHeader.Font = new Font(privateFonts.Families[0], 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tutorialLabelHeader.ForeColor = Color.RoyalBlue;
            tutorialLabelHeader.Location = new Point(538, 41);
            tutorialLabelHeader.Name = "tutorialLabelHeader";
            tutorialLabelHeader.Size = new Size(345, 40);
            tutorialLabelHeader.TabIndex = 0;
            tutorialLabelHeader.Text = "Tutorial";
            // 
            // tutorialButtonBack
            // 
            tutorialButtonBack.Anchor = AnchorStyles.None;
            tutorialButtonBack.BackColor = Color.RoyalBlue;
            tutorialButtonBack.Font = new Font(privateFonts.Families[0], 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tutorialButtonBack.Location = new Point(598, 632);
            tutorialButtonBack.Name = "tutorialButtonBack";
            tutorialButtonBack.Size = new Size(225, 90);
            tutorialButtonBack.TabIndex = 1;
            tutorialButtonBack.Text = "Back";
            tutorialButtonBack.UseVisualStyleBackColor = false;
            tutorialButtonBack.Click += TutorialButtonBack_Click;
            tutorialButtonBack.MouseEnter += TutorialButtonBack_MouseEnter;
            tutorialButtonBack.MouseLeave += TutorialButtonBack_MouseLeave;
            // 
            // audioTableLayoutPanelMain
            // 
            audioTableLayoutPanelMain.BackColor = Color.Black;
            audioTableLayoutPanelMain.BackgroundImage = Properties.Resources.backgroundInnerMenu;
            audioTableLayoutPanelMain.ColumnCount = 1;
            audioTableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            audioTableLayoutPanelMain.Controls.Add(audioLabelHeader, 0, 0);
            audioTableLayoutPanelMain.Controls.Add(audioButtonBack, 0, 3);
            audioTableLayoutPanelMain.Controls.Add(audioTableLayoutPanelContents, 0, 2);
            audioTableLayoutPanelMain.Dock = DockStyle.Fill;
            audioTableLayoutPanelMain.Location = new Point(0, 0);
            audioTableLayoutPanelMain.Name = "audioTableLayoutPanelMain";
            audioTableLayoutPanelMain.RowCount = 4;
            audioTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 15.1402264F));
            audioTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 6.74662828F));
            audioTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 57.2801933F));
            audioTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 20.8329525F));
            audioTableLayoutPanelMain.Size = new Size(1422, 763);
            audioTableLayoutPanelMain.TabIndex = 9;
            audioTableLayoutPanelMain.Visible = false;
            // 
            // audioLabelHeader
            // 
            audioLabelHeader.Anchor = AnchorStyles.None;
            audioLabelHeader.AutoSize = true;
            audioLabelHeader.BackColor = Color.Transparent;
            audioLabelHeader.Font = new Font(privateFonts.Families[0], 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            audioLabelHeader.ForeColor = Color.RoyalBlue;
            audioLabelHeader.Location = new Point(600, 37);
            audioLabelHeader.Name = "audioLabelHeader";
            audioLabelHeader.Size = new Size(222, 40);
            audioLabelHeader.TabIndex = 1;
            audioLabelHeader.Text = "Audio";
            // 
            // audioButtonBack
            // 
            audioButtonBack.Anchor = AnchorStyles.None;
            audioButtonBack.BackColor = Color.RoyalBlue;
            audioButtonBack.Font = new Font(privateFonts.Families[0], 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            audioButtonBack.Location = new Point(598, 638);
            audioButtonBack.Name = "audioButtonBack";
            audioButtonBack.Size = new Size(225, 90);
            audioButtonBack.TabIndex = 0;
            audioButtonBack.Text = "Back";
            audioButtonBack.UseVisualStyleBackColor = false;
            audioButtonBack.Click += AudioButtonBack_Click;
            audioButtonBack.MouseEnter += AudioButtonBack_MouseEnter;
            audioButtonBack.MouseLeave += AudioButtonBack_MouseLeave;
            // 
            // audioTableLayoutPanelContents
            // 
            audioTableLayoutPanelContents.BackColor = Color.Transparent;
            audioTableLayoutPanelContents.ColumnCount = 6;
            audioTableLayoutPanelContents.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.7487717F));
            audioTableLayoutPanelContents.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.73399F));
            audioTableLayoutPanelContents.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.8937378F));
            audioTableLayoutPanelContents.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.133709F));
            audioTableLayoutPanelContents.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.8634768F));
            audioTableLayoutPanelContents.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.6263208F));
            audioTableLayoutPanelContents.Controls.Add(audioLabelVolume, 1, 1);
            audioTableLayoutPanelContents.Controls.Add(audioButtonMuteSfx, 4, 1);
            audioTableLayoutPanelContents.Controls.Add(audioLabelSfxVolume, 3, 1);
            audioTableLayoutPanelContents.Dock = DockStyle.Fill;
            audioTableLayoutPanelContents.Location = new Point(3, 169);
            audioTableLayoutPanelContents.Name = "audioTableLayoutPanelContents";
            audioTableLayoutPanelContents.RowCount = 3;
            audioTableLayoutPanelContents.RowStyles.Add(new RowStyle(SizeType.Percent, 29.81389F));
            audioTableLayoutPanelContents.RowStyles.Add(new RowStyle(SizeType.Percent, 40.3722229F));
            audioTableLayoutPanelContents.RowStyles.Add(new RowStyle(SizeType.Percent, 29.81389F));
            audioTableLayoutPanelContents.Size = new Size(1416, 431);
            audioTableLayoutPanelContents.TabIndex = 2;
            // 
            // audioLabelVolume
            // 
            audioLabelVolume.Anchor = AnchorStyles.None;
            audioLabelVolume.AutoSize = true;
            audioLabelVolume.BackColor = Color.Transparent;
            audioLabelVolume.Font = new Font(privateFonts.Families[0], 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            audioLabelVolume.ForeColor = Color.RoyalBlue;
            audioLabelVolume.Location = new Point(250, 198);
            audioLabelVolume.Name = "audioLabelVolume";
            audioLabelVolume.Size = new Size(225, 34);
            audioLabelVolume.TabIndex = 0;
            audioLabelVolume.Text = "Volume";
            // 
            // audioButtonMuteSfx
            // 
            audioButtonMuteSfx.Anchor = AnchorStyles.None;
            audioButtonMuteSfx.BackColor = Color.RoyalBlue;
            audioButtonMuteSfx.Font = new Font(privateFonts.Families[0], 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            audioButtonMuteSfx.Location = new Point(1091, 185);
            audioButtonMuteSfx.Name = "audioButtonMuteSfx";
            audioButtonMuteSfx.Size = new Size(150, 59);
            audioButtonMuteSfx.TabIndex = 2;
            audioButtonMuteSfx.Text = " Mute ";
            audioButtonMuteSfx.UseVisualStyleBackColor = false;
            audioButtonMuteSfx.Click += AudioButtonMute_Click;
            audioButtonMuteSfx.MouseEnter += AudioButtonMute_MouseEnter;
            audioButtonMuteSfx.MouseLeave += AudioButtonMute_MouseLeave;
            // 
            // audioLabelSfxVolume
            // 
            audioLabelSfxVolume.Anchor = AnchorStyles.None;
            audioLabelSfxVolume.AutoSize = true;
            audioLabelSfxVolume.Font = new Font(privateFonts.Families[0], 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            audioLabelSfxVolume.ForeColor = Color.RoyalBlue;
            audioLabelSfxVolume.Location = new Point(928, 200);
            audioLabelSfxVolume.Name = "audioLabelSfxVolume";
            audioLabelSfxVolume.Size = new Size(137, 30);
            audioLabelSfxVolume.TabIndex = 4;
            audioLabelSfxVolume.Text = " 50%";
            // 
            // playTableLayoutPanelMain
            // 
            playTableLayoutPanelMain.BackColor = Color.Black;
            playTableLayoutPanelMain.BackgroundImage = Properties.Resources.backgroundInnerMenu;
            playTableLayoutPanelMain.ColumnCount = 1;
            playTableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            playTableLayoutPanelMain.Controls.Add(playButtonBack, 0, 2);
            playTableLayoutPanelMain.Controls.Add(playLabelHeader, 0, 0);
            playTableLayoutPanelMain.Controls.Add(playTableLayoutPanelContents, 0, 1);
            playTableLayoutPanelMain.Dock = DockStyle.Fill;
            playTableLayoutPanelMain.Location = new Point(0, 0);
            playTableLayoutPanelMain.Name = "playTableLayoutPanelMain";
            playTableLayoutPanelMain.RowCount = 3;
            playTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 14.9519892F));
            playTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 64.4065552F));
            playTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 20.6414547F));
            playTableLayoutPanelMain.Size = new Size(1422, 763);
            playTableLayoutPanelMain.TabIndex = 10;
            playTableLayoutPanelMain.Visible = false;
            // 
            // playButtonBack
            // 
            playButtonBack.Anchor = AnchorStyles.None;
            playButtonBack.BackColor = Color.RoyalBlue;
            playButtonBack.Font = new Font(privateFonts.Families[0], 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playButtonBack.Location = new Point(598, 639);
            playButtonBack.Name = "playButtonBack";
            playButtonBack.Size = new Size(225, 90);
            playButtonBack.TabIndex = 0;
            playButtonBack.Text = "Back";
            playButtonBack.UseVisualStyleBackColor = false;
            playButtonBack.Click += PlayButtonBack_Click;
            playButtonBack.MouseEnter += PlayButtonBack_MouseEnter;
            playButtonBack.MouseLeave += PlayButtonBack_MouseLeave;
            // 
            // playLabelHeader
            // 
            playLabelHeader.Anchor = AnchorStyles.None;
            playLabelHeader.AutoSize = true;
            playLabelHeader.BackColor = Color.Transparent;
            playLabelHeader.Font = new Font(privateFonts.Families[0], 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playLabelHeader.ForeColor = Color.RoyalBlue;
            playLabelHeader.Location = new Point(620, 37);
            playLabelHeader.Name = "playLabelHeader";
            playLabelHeader.Size = new Size(181, 40);
            playLabelHeader.TabIndex = 1;
            playLabelHeader.Text = "Play";
            // 
            // playTableLayoutPanelContents
            // 
            playTableLayoutPanelContents.BackColor = Color.Transparent;
            playTableLayoutPanelContents.ColumnCount = 1;
            playTableLayoutPanelContents.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            playTableLayoutPanelContents.Controls.Add(playButtonEasy, 0, 2);
            playTableLayoutPanelContents.Controls.Add(playLabelChoose, 0, 1);
            playTableLayoutPanelContents.Controls.Add(playButtonMedium, 0, 3);
            playTableLayoutPanelContents.Controls.Add(playTableLayoutPanelComponentsCustom, 0, 5);
            playTableLayoutPanelContents.Controls.Add(playButtonHard, 0, 4);
            playTableLayoutPanelContents.Dock = DockStyle.Fill;
            playTableLayoutPanelContents.Location = new Point(3, 117);
            playTableLayoutPanelContents.Name = "playTableLayoutPanelContents";
            playTableLayoutPanelContents.RowCount = 7;
            playTableLayoutPanelContents.RowStyles.Add(new RowStyle(SizeType.Percent, 4.81252146F));
            playTableLayoutPanelContents.RowStyles.Add(new RowStyle(SizeType.Percent, 15.6406937F));
            playTableLayoutPanelContents.RowStyles.Add(new RowStyle(SizeType.Percent, 15.6406937F));
            playTableLayoutPanelContents.RowStyles.Add(new RowStyle(SizeType.Percent, 15.6406937F));
            playTableLayoutPanelContents.RowStyles.Add(new RowStyle(SizeType.Percent, 15.6406937F));
            playTableLayoutPanelContents.RowStyles.Add(new RowStyle(SizeType.Percent, 27.8121777F));
            playTableLayoutPanelContents.RowStyles.Add(new RowStyle(SizeType.Percent, 4.81252146F));
            playTableLayoutPanelContents.Size = new Size(1416, 485);
            playTableLayoutPanelContents.TabIndex = 2;
            // 
            // playButtonEasy
            // 
            playButtonEasy.Anchor = AnchorStyles.None;
            playButtonEasy.BackColor = Color.RoyalBlue;
            playButtonEasy.Font = new Font(privateFonts.Families[0], 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playButtonEasy.Location = new Point(520, 110);
            playButtonEasy.Name = "playButtonEasy";
            playButtonEasy.Size = new Size(375, 50);
            playButtonEasy.TabIndex = 1;
            playButtonEasy.Text = "Easy   (5 waves)";
            playButtonEasy.UseVisualStyleBackColor = false;
            playButtonEasy.Click += PlayButtonEasy_Click;
            playButtonEasy.MouseEnter += PlayButtonEasy_MouseEnter;
            playButtonEasy.MouseLeave += PlayButtonEasy_MouseLeave;
            // 
            // playLabelChoose
            // 
            playLabelChoose.Anchor = AnchorStyles.None;
            playLabelChoose.AutoSize = true;
            playLabelChoose.BackColor = Color.Transparent;
            playLabelChoose.Font = new Font(privateFonts.Families[0], 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playLabelChoose.ForeColor = Color.RoyalBlue;
            playLabelChoose.Location = new Point(422, 45);
            playLabelChoose.Name = "playLabelChoose";
            playLabelChoose.Size = new Size(571, 30);
            playLabelChoose.TabIndex = 2;
            playLabelChoose.Text = "Choose difficulty:";
            // 
            // playButtonMedium
            // 
            playButtonMedium.Anchor = AnchorStyles.None;
            playButtonMedium.BackColor = Color.RoyalBlue;
            playButtonMedium.Font = new Font(privateFonts.Families[0], 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playButtonMedium.Location = new Point(520, 185);
            playButtonMedium.Name = "playButtonMedium";
            playButtonMedium.Size = new Size(375, 50);
            playButtonMedium.TabIndex = 3;
            playButtonMedium.Text = "Medium (8 waves)";
            playButtonMedium.UseVisualStyleBackColor = false;
            playButtonMedium.Click += PlayButtonMedium_Click;
            playButtonMedium.MouseEnter += PlayButtonMedium_MouseEnter;
            playButtonMedium.MouseLeave += PlayButtonMedium_MouseLeave;
            // 
            // playTableLayoutPanelComponentsCustom
            // 
            playTableLayoutPanelComponentsCustom.ColumnCount = 6;
            playTableLayoutPanelComponentsCustom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.7517738F));
            playTableLayoutPanelComponentsCustom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.1063833F));
            playTableLayoutPanelComponentsCustom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.716312F));
            playTableLayoutPanelComponentsCustom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.2836876F));
            playTableLayoutPanelComponentsCustom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.0354614F));
            playTableLayoutPanelComponentsCustom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.3900719F));
            playTableLayoutPanelComponentsCustom.Controls.Add(playLabelCustom, 1, 0);
            playTableLayoutPanelComponentsCustom.Controls.Add(playLabelWaves, 3, 0);
            playTableLayoutPanelComponentsCustom.Controls.Add(playTextBoxWaveInput, 2, 0);
            playTableLayoutPanelComponentsCustom.Controls.Add(playButtonStart, 4, 0);
            playTableLayoutPanelComponentsCustom.Controls.Add(playLabelWaveError, 5, 0);
            playTableLayoutPanelComponentsCustom.Dock = DockStyle.Fill;
            playTableLayoutPanelComponentsCustom.Location = new Point(3, 326);
            playTableLayoutPanelComponentsCustom.Name = "playTableLayoutPanelComponentsCustom";
            playTableLayoutPanelComponentsCustom.RowCount = 1;
            playTableLayoutPanelComponentsCustom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            playTableLayoutPanelComponentsCustom.Size = new Size(1410, 128);
            playTableLayoutPanelComponentsCustom.TabIndex = 0;
            // 
            // playLabelCustom
            // 
            playLabelCustom.Anchor = AnchorStyles.None;
            playLabelCustom.AutoSize = true;
            playLabelCustom.BackColor = Color.Transparent;
            playLabelCustom.Font = new Font(privateFonts.Families[0], 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playLabelCustom.ForeColor = Color.RoyalBlue;
            playLabelCustom.Location = new Point(365, 52);
            playLabelCustom.Name = "playLabelCustom";
            playLabelCustom.Size = new Size(178, 23);
            playLabelCustom.TabIndex = 0;
            playLabelCustom.Text = "Custom:";
            // 
            // playLabelWaves
            // 
            playLabelWaves.Anchor = AnchorStyles.None;
            playLabelWaves.AutoSize = true;
            playLabelWaves.BackColor = Color.Transparent;
            playLabelWaves.Font = new Font(privateFonts.Families[0], 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playLabelWaves.ForeColor = Color.RoyalBlue;
            playLabelWaves.Location = new Point(703, 52);
            playLabelWaves.Name = "playLabelWaves";
            playLabelWaves.Size = new Size(130, 23);
            playLabelWaves.TabIndex = 1;
            playLabelWaves.Text = "Waves";
            // 
            // playTextBoxWaveInput
            // 
            playTextBoxWaveInput.Anchor = AnchorStyles.None;
            playTextBoxWaveInput.BackColor = Color.LightSteelBlue;
            playTextBoxWaveInput.Font = new Font(privateFonts.Families[0], 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playTextBoxWaveInput.Location = new Point(589, 44);
            playTextBoxWaveInput.MaxLength = 2;
            playTextBoxWaveInput.Name = "playTextBoxWaveInput";
            playTextBoxWaveInput.Size = new Size(78, 40);
            playTextBoxWaveInput.TabIndex = 2;
            // 
            // playButtonStart
            // 
            playButtonStart.Anchor = AnchorStyles.None;
            playButtonStart.BackColor = Color.RoyalBlue;
            playButtonStart.Font = new Font(privateFonts.Families[0], 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playButtonStart.Location = new Point(862, 38);
            playButtonStart.Name = "playButtonStart";
            playButtonStart.Size = new Size(166, 51);
            playButtonStart.TabIndex = 3;
            playButtonStart.Text = "Start";
            playButtonStart.UseVisualStyleBackColor = false;
            playButtonStart.Click += PlayButtonStart_Click;
            playButtonStart.MouseEnter += PlayButtonStart_MouseEnter;
            playButtonStart.MouseLeave += PlayButtonStart_MouseLeave;
            // 
            // playLabelWaveError
            // 
            playLabelWaveError.Anchor = AnchorStyles.None;
            playLabelWaveError.AutoSize = true;
            playLabelWaveError.Font = new Font(privateFonts.Families[0], 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playLabelWaveError.ForeColor = Color.Red;
            playLabelWaveError.Location = new Point(1230, 52);
            playLabelWaveError.Name = "playLabelWaveError";
            playLabelWaveError.Size = new Size(0, 23);
            playLabelWaveError.TabIndex = 4;
            // 
            // playButtonHard
            // 
            playButtonHard.Anchor = AnchorStyles.None;
            playButtonHard.BackColor = Color.RoyalBlue;
            playButtonHard.Font = new Font(privateFonts.Families[0], 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playButtonHard.Location = new Point(520, 260);
            playButtonHard.Name = "playButtonHard";
            playButtonHard.Size = new Size(375, 50);
            playButtonHard.TabIndex = 4;
            playButtonHard.Text = "Hard  (12 waves)";
            playButtonHard.UseVisualStyleBackColor = false;
            playButtonHard.Click += PlayButtonHard_Click;
            playButtonHard.MouseEnter += PlayButtonHard_MouseEnter;
            playButtonHard.MouseLeave += PlayButtonHard_MouseLeave;
            // 
            // startingTableLayoutPanelMain
            // 
            startingTableLayoutPanelMain.BackgroundImage = Properties.Resources.backgroundInnerMenu;
            startingTableLayoutPanelMain.ColumnCount = 1;
            startingTableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            startingTableLayoutPanelMain.Controls.Add(startingLabelStarting, 0, 1);
            startingTableLayoutPanelMain.Dock = DockStyle.Fill;
            startingTableLayoutPanelMain.Location = new Point(0, 0);
            startingTableLayoutPanelMain.Name = "startingTableLayoutPanelMain";
            startingTableLayoutPanelMain.RowCount = 3;
            startingTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 21.8328838F));
            startingTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 78.1671143F));
            startingTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 339F));
            startingTableLayoutPanelMain.Size = new Size(1422, 763);
            startingTableLayoutPanelMain.TabIndex = 11;
            startingTableLayoutPanelMain.Visible = false;
            // 
            // startingLabelStarting
            // 
            startingLabelStarting.Anchor = AnchorStyles.None;
            startingLabelStarting.AutoSize = true;
            startingLabelStarting.BackColor = Color.Transparent;
            startingLabelStarting.Font = new Font(privateFonts.Families[0], 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            startingLabelStarting.ForeColor = Color.RoyalBlue;
            startingLabelStarting.Location = new Point(711, 237);
            startingLabelStarting.Name = "startingLabelStarting";
            startingLabelStarting.Size = new Size(0, 40);
            startingLabelStarting.TabIndex = 0;
            // 
            // gameButtonMenu
            // 
            gameButtonMenu.Anchor = AnchorStyles.None;
            gameButtonMenu.BackColor = Color.RoyalBlue;
            gameButtonMenu.Font = new Font(privateFonts.Families[0], 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gameButtonMenu.Location = new Point(1185, 12);
            gameButtonMenu.Name = "gameButtonMenu";
            gameButtonMenu.Size = new Size(225, 75);
            gameButtonMenu.TabIndex = 1;
            gameButtonMenu.Text = "Menu";
            gameButtonMenu.UseVisualStyleBackColor = false;
            gameButtonMenu.Click += GameButtonMenu_Click;
            gameButtonMenu.MouseEnter += GameButtonMenu_MouseEnter;
            gameButtonMenu.MouseLeave += GameButtonMenu_MouseLeave;
            // 
            // gameLabelWave
            // 
            gameLabelWave.Anchor = AnchorStyles.Left;
            gameLabelWave.AutoSize = true;
            gameLabelWave.BackColor = Color.DimGray;
            gameLabelWave.Font = new Font(privateFonts.Families[0], 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gameLabelWave.ForeColor = Color.White;
            gameLabelWave.Location = new Point(856, 36);
            gameLabelWave.Name = "gameLabelWave";
            gameLabelWave.Size = new Size(302, 28);
            gameLabelWave.TabIndex = 0;
            gameLabelWave.Text = "Wave:1 /15";
            // 
            // pausedTableLayoutPanelMain
            // 
            pausedTableLayoutPanelMain.BackgroundImage = Properties.Resources.backgroundInnerMenu;
            pausedTableLayoutPanelMain.ColumnCount = 1;
            pausedTableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pausedTableLayoutPanelMain.Controls.Add(pausedLabelPaused, 0, 1);
            pausedTableLayoutPanelMain.Controls.Add(pausedButtonReturn, 0, 2);
            pausedTableLayoutPanelMain.Controls.Add(pausedButtonExit, 0, 3);
            pausedTableLayoutPanelMain.Dock = DockStyle.Fill;
            pausedTableLayoutPanelMain.Location = new Point(0, 0);
            pausedTableLayoutPanelMain.Name = "pausedTableLayoutPanelMain";
            pausedTableLayoutPanelMain.RowCount = 5;
            pausedTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 23.171814F));
            pausedTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 13.0444984F));
            pausedTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 16.305624F));
            pausedTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 16.305624F));
            pausedTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 31.17244F));
            pausedTableLayoutPanelMain.Size = new Size(1422, 763);
            pausedTableLayoutPanelMain.TabIndex = 13;
            pausedTableLayoutPanelMain.Visible = false;
            // 
            // pausedLabelPaused
            // 
            pausedLabelPaused.Anchor = AnchorStyles.None;
            pausedLabelPaused.AutoSize = true;
            pausedLabelPaused.Font = new Font(privateFonts.Families[0], 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pausedLabelPaused.ForeColor = Color.RoyalBlue;
            pausedLabelPaused.Location = new Point(538, 205);
            pausedLabelPaused.Name = "pausedLabelPaused";
            pausedLabelPaused.Size = new Size(345, 40);
            pausedLabelPaused.TabIndex = 0;
            pausedLabelPaused.Text = "[Paused]";
            // 
            // pausedButtonReturn
            // 
            pausedButtonReturn.Anchor = AnchorStyles.None;
            pausedButtonReturn.BackColor = Color.RoyalBlue;
            pausedButtonReturn.Font = new Font(privateFonts.Families[0], 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pausedButtonReturn.Location = new Point(523, 292);
            pausedButtonReturn.Name = "pausedButtonReturn";
            pausedButtonReturn.Size = new Size(375, 90);
            pausedButtonReturn.TabIndex = 1;
            pausedButtonReturn.Text = "Return";
            pausedButtonReturn.UseVisualStyleBackColor = false;
            pausedButtonReturn.Click += PausedButtonReturn_Click;
            pausedButtonReturn.MouseEnter += PausedButtonReturn_MouseEnter;
            pausedButtonReturn.MouseLeave += PausedButtonReturn_MouseLeave;
            // 
            // pausedButtonExit
            // 
            pausedButtonExit.Anchor = AnchorStyles.None;
            pausedButtonExit.BackColor = Color.RoyalBlue;
            pausedButtonExit.Font = new Font(privateFonts.Families[0], 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pausedButtonExit.Location = new Point(523, 416);
            pausedButtonExit.Name = "pausedButtonExit";
            pausedButtonExit.Size = new Size(375, 90);
            pausedButtonExit.TabIndex = 2;
            pausedButtonExit.Text = "Exit";
            pausedButtonExit.UseVisualStyleBackColor = false;
            pausedButtonExit.Click += PausedButtonExit_Click;
            pausedButtonExit.MouseEnter += PausedButtonExit_MouseEnter;
            pausedButtonExit.MouseLeave += PausedButtonExit_MouseLeave;
            // 
            // gamePanelMain
            // 
            gamePanelMain.BackColor = Color.Transparent;
            gamePanelMain.BackgroundImage = Properties.Resources.backgroundGame;
            gamePanelMain.Controls.Add(gameLabelStart);
            gamePanelMain.Controls.Add(gameButtonMenu);
            gamePanelMain.Controls.Add(gameLabelWave);
            gamePanelMain.Dock = DockStyle.Fill;
            gamePanelMain.ForeColor = Color.Transparent;
            gamePanelMain.Location = new Point(0, 0);
            gamePanelMain.Name = "gamePanelMain";
            gamePanelMain.Size = new Size(1422, 763);
            gamePanelMain.TabIndex = 14;
            gamePanelMain.Visible = false;
            gamePanelMain.VisibleChanged += GamePanelMain_VisibleChanged;
            // 
            // gameLabelStart
            // 
            gameLabelStart.Anchor = AnchorStyles.None;
            gameLabelStart.AutoSize = true;
            gameLabelStart.Font = new Font(privateFonts.Families[0], 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gameLabelStart.ForeColor = Color.RoyalBlue;
            gameLabelStart.Location = new Point(256, 394);
            gameLabelStart.Name = "gameLabelStart";
            gameLabelStart.Size = new Size(0, 30);
            gameLabelStart.TabIndex = 2;
            // 
            // lostTableLayoutPanelMain
            // 
            lostTableLayoutPanelMain.BackgroundImage = Properties.Resources.backgroundLost;
            lostTableLayoutPanelMain.ColumnCount = 1;
            lostTableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            lostTableLayoutPanelMain.Controls.Add(lostLabelLost, 0, 1);
            lostTableLayoutPanelMain.Controls.Add(lostButtonRestart, 0, 3);
            lostTableLayoutPanelMain.Controls.Add(lostButtonMainMenu, 0, 4);
            lostTableLayoutPanelMain.Dock = DockStyle.Fill;
            lostTableLayoutPanelMain.Location = new Point(0, 0);
            lostTableLayoutPanelMain.Name = "lostTableLayoutPanelMain";
            lostTableLayoutPanelMain.RowCount = 6;
            lostTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 34.8623848F));
            lostTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 15.8584538F));
            lostTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 4.587156F));
            lostTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 17.4311924F));
            lostTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 15.0720835F));
            lostTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.1887283F));
            lostTableLayoutPanelMain.Size = new Size(1422, 763);
            lostTableLayoutPanelMain.TabIndex = 15;
            lostTableLayoutPanelMain.Visible = false;
            lostTableLayoutPanelMain.VisibleChanged += LostTableLayoutPanelMain_VisibleChanged;
            // 
            // lostLabelLost
            // 
            lostLabelLost.Anchor = AnchorStyles.None;
            lostLabelLost.AutoSize = true;
            lostLabelLost.BackColor = Color.White;
            lostLabelLost.Font = new Font(privateFonts.Families[0], 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lostLabelLost.ForeColor = Color.Red;
            lostLabelLost.Location = new Point(58, 315);
            lostLabelLost.Name = "lostLabelLost";
            lostLabelLost.Size = new Size(1306, 23);
            lostLabelLost.TabIndex = 0;
            lostLabelLost.Text = "You lost! The aliens invaded and enslaved your race...";
            // 
            // lostButtonRestart
            // 
            lostButtonRestart.Anchor = AnchorStyles.None;
            lostButtonRestart.BackColor = Color.Firebrick;
            lostButtonRestart.Font = new Font(privateFonts.Families[0], 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lostButtonRestart.ForeColor = SystemColors.ControlText;
            lostButtonRestart.Location = new Point(523, 443);
            lostButtonRestart.Name = "lostButtonRestart";
            lostButtonRestart.Size = new Size(375, 90);
            lostButtonRestart.TabIndex = 1;
            lostButtonRestart.Text = "Restart";
            lostButtonRestart.UseVisualStyleBackColor = false;
            lostButtonRestart.Click += LostButtonRestart_Click;
            lostButtonRestart.MouseEnter += LostButtonRestart_MouseEnter;
            lostButtonRestart.MouseLeave += LostButtonRestart_MouseLeave;
            // 
            // lostButtonMainMenu
            // 
            lostButtonMainMenu.Anchor = AnchorStyles.None;
            lostButtonMainMenu.BackColor = Color.Firebrick;
            lostButtonMainMenu.Font = new Font(privateFonts.Families[0], 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lostButtonMainMenu.Location = new Point(523, 567);
            lostButtonMainMenu.Name = "lostButtonMainMenu";
            lostButtonMainMenu.Size = new Size(375, 90);
            lostButtonMainMenu.TabIndex = 2;
            lostButtonMainMenu.Text = "Main Menu";
            lostButtonMainMenu.UseVisualStyleBackColor = false;
            lostButtonMainMenu.Click += LostButtonMainMenu_Click;
            lostButtonMainMenu.MouseEnter += LostButtonMainMenu_MouseEnter;
            lostButtonMainMenu.MouseLeave += LostButtonMainMenu_MouseLeave;
            // 
            // wonTableLayoutPanelMain
            // 
            wonTableLayoutPanelMain.BackgroundImage = Properties.Resources.backgroundWon1;
            wonTableLayoutPanelMain.ColumnCount = 1;
            wonTableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            wonTableLayoutPanelMain.Controls.Add(wonLabelWon, 0, 1);
            wonTableLayoutPanelMain.Controls.Add(wonButtonMainMenu, 0, 3);
            wonTableLayoutPanelMain.Dock = DockStyle.Fill;
            wonTableLayoutPanelMain.Location = new Point(0, 0);
            wonTableLayoutPanelMain.Name = "wonTableLayoutPanelMain";
            wonTableLayoutPanelMain.RowCount = 5;
            wonTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 34.60026F));
            wonTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 17.0380077F));
            wonTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 5.63564873F));
            wonTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 13.6304064F));
            wonTableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 28.964613F));
            wonTableLayoutPanelMain.Size = new Size(1422, 763);
            wonTableLayoutPanelMain.TabIndex = 16;
            wonTableLayoutPanelMain.Visible = false;
            wonTableLayoutPanelMain.VisibleChanged += WonTableLayoutPanelMain_VisibleChanged;
            // 
            // wonLabelWon
            // 
            wonLabelWon.Anchor = AnchorStyles.None;
            wonLabelWon.AutoSize = true;
            wonLabelWon.BackColor = Color.Transparent;
            wonLabelWon.Font = new Font(privateFonts.Families[0], 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            wonLabelWon.ForeColor = Color.Green;
            wonLabelWon.Location = new Point(66, 319);
            wonLabelWon.Name = "wonLabelWon";
            wonLabelWon.Size = new Size(1290, 20);
            wonLabelWon.TabIndex = 0;
            wonLabelWon.Text = "Congratulations, you won! The human race is forever grateful.";
            // 
            // wonButtonMainMenu
            // 
            wonButtonMainMenu.Anchor = AnchorStyles.None;
            wonButtonMainMenu.BackColor = Color.DarkGreen;
            wonButtonMainMenu.Font = new Font(privateFonts.Families[0], 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            wonButtonMainMenu.Location = new Point(523, 444);
            wonButtonMainMenu.Name = "wonButtonMainMenu";
            wonButtonMainMenu.Size = new Size(375, 90);
            wonButtonMainMenu.TabIndex = 1;
            wonButtonMainMenu.Text = "Main Menu";
            wonButtonMainMenu.UseVisualStyleBackColor = false;
            wonButtonMainMenu.Click += WonButtonMainMenu_Click;
            wonButtonMainMenu.MouseEnter += WonButtonMainMenu_MouseEnter;
            wonButtonMainMenu.MouseLeave += WonButtonMainMenu_MouseLeave;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(16F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1422, 763);
            Controls.Add(audioTableLayoutPanelMain);
            Controls.Add(exitTableLayoutPanelExiting);
            Controls.Add(exitTableLayoutPanelMain);
            Controls.Add(tutorialTableLayoutPanelMain);
            Controls.Add(mainTableLayoutPanelMain);
            Controls.Add(pausedTableLayoutPanelMain);
            Controls.Add(wonTableLayoutPanelMain);
            Controls.Add(lostTableLayoutPanelMain);
            Controls.Add(gamePanelMain);
            Controls.Add(startingTableLayoutPanelMain);
            Controls.Add(playTableLayoutPanelMain);
            Font = new Font(privateFonts.Families[0], 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = Properties.Resources.icon;
            Margin = new Padding(6, 2, 6, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMain";
            Text = "Space Defender";
            Load += FormMain_Load;
            exitTableLayoutPanelExiting.ResumeLayout(false);
            exitTableLayoutPanelExiting.PerformLayout();
            exitTableLayoutPanelMain.ResumeLayout(false);
            exitTableLayoutPanelMain.PerformLayout();
            exitTableLayoutPanelButtons.ResumeLayout(false);
            mainTableLayoutPanelMain.ResumeLayout(false);
            mainTableLayoutPanelMain.PerformLayout();
            tutorialTableLayoutPanelMain.ResumeLayout(false);
            tutorialTableLayoutPanelMain.PerformLayout();
            tutorialTableLayoutPanelContents.ResumeLayout(false);
            audioTableLayoutPanelMain.ResumeLayout(false);
            audioTableLayoutPanelMain.PerformLayout();
            audioTableLayoutPanelContents.ResumeLayout(false);
            audioTableLayoutPanelContents.PerformLayout();
            playTableLayoutPanelMain.ResumeLayout(false);
            playTableLayoutPanelMain.PerformLayout();
            playTableLayoutPanelContents.ResumeLayout(false);
            playTableLayoutPanelContents.PerformLayout();
            playTableLayoutPanelComponentsCustom.ResumeLayout(false);
            playTableLayoutPanelComponentsCustom.PerformLayout();
            startingTableLayoutPanelMain.ResumeLayout(false);
            startingTableLayoutPanelMain.PerformLayout();
            pausedTableLayoutPanelMain.ResumeLayout(false);
            pausedTableLayoutPanelMain.PerformLayout();
            gamePanelMain.ResumeLayout(false);
            gamePanelMain.PerformLayout();
            lostTableLayoutPanelMain.ResumeLayout(false);
            lostTableLayoutPanelMain.PerformLayout();
            wonTableLayoutPanelMain.ResumeLayout(false);
            wonTableLayoutPanelMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GlobalUtilsGUI.DoubleBufferedTableLayoutPanel exitTableLayoutPanelExiting;
        private Label exitLabelExiting;
        private GlobalUtilsGUI.DoubleBufferedTableLayoutPanel exitTableLayoutPanelMain;
        private Label exitLabelConfirm;
        private GlobalUtilsGUI.DoubleBufferedTableLayoutPanel exitTableLayoutPanelButtons;
        private Button exitButtonYes;
        private Button exitButtonNo;
        private GlobalUtilsGUI.DoubleBufferedTableLayoutPanel mainTableLayoutPanelMain;
        private Button mainButtonAudio;
        private Label mainLabelTitle;
        private Button mainButtonPlay;
        private Button mainButtonTutorial;
        private Button mainButtonExit;
        private GlobalUtilsGUI.DoubleBufferedTableLayoutPanel tutorialTableLayoutPanelMain;
        private Label tutorialLabelHeader;
        private Button tutorialButtonBack;
        private GlobalUtilsGUI.DoubleBufferedTableLayoutPanel tutorialTableLayoutPanelContents;
        private RichTextBox tutorialRichTextBoxTutorial;
        private GlobalUtilsGUI.DoubleBufferedTableLayoutPanel audioTableLayoutPanelMain;
        private Button audioButtonBack;
        private Label audioLabelHeader;
        private GlobalUtilsGUI.DoubleBufferedTableLayoutPanel audioTableLayoutPanelContents;
        private Label audioLabelVolume;
        private Button audioButtonMuteSfx;
        private GlobalUtilsGUI.DoubleBufferedTableLayoutPanel playTableLayoutPanelMain;
        private Button playButtonBack;
        private Label playLabelHeader;
        private GlobalUtilsGUI.DoubleBufferedTableLayoutPanel playTableLayoutPanelContents;
        private Button playButtonEasy;
        private Label playLabelChoose;
        private Button playButtonMedium;
        private GlobalUtilsGUI.DoubleBufferedTableLayoutPanel playTableLayoutPanelComponentsCustom;
        private Button playButtonHard;
        private Label playLabelCustom;
        private Label playLabelWaves;
        private TextBox playTextBoxWaveInput;
        private Button playButtonStart;
        private GlobalUtilsGUI.DoubleBufferedTableLayoutPanel startingTableLayoutPanelMain;
        private Label startingLabelStarting;
        private Label playLabelWaveError;
        private Label gameLabelWave;
        private GlobalUtilsGUI.DoubleBufferedTableLayoutPanel pausedTableLayoutPanelMain;
        private Label pausedLabelPaused;
        private Button pausedButtonReturn;
        private Button pausedButtonExit;
        private Button gameButtonMenu;
        private GlobalUtilsGUI.DoubleBufferedPanel gamePanelMain;
        private Label gameLabelStart;
        private TableLayoutPanel lostTableLayoutPanelMain;
        private Label lostLabelLost;
        private Button lostButtonRestart;
        private Button lostButtonMainMenu;
        private TableLayoutPanel wonTableLayoutPanelMain;
        private Label wonLabelWon;
        private Button wonButtonMainMenu;
        private Label audioLabelSfxVolume;
    }
}
