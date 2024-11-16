namespace CoTSim
{
    partial class Form1
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            bn_SendCoT_PLI = new Button();
            rtb_Debug = new RichTextBox();
            label1 = new Label();
            tb_StaleMinutes = new TextBox();
            tree_Xml = new TreeView();
            bn_Quit = new Button();
            bn_Clear = new Button();
            cb_Team = new ComboBox();
            bn_SendCoT2 = new Button();
            BN_SendContact = new Button();
            BN_Listen = new Button();
            groupBox1 = new GroupBox();
            TB_IP = new TextBox();
            TB_Port = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // bn_SendCoT_PLI
            // 
            bn_SendCoT_PLI.Location = new Point(69, 167);
            bn_SendCoT_PLI.Name = "bn_SendCoT_PLI";
            bn_SendCoT_PLI.Size = new Size(154, 34);
            bn_SendCoT_PLI.TabIndex = 0;
            bn_SendCoT_PLI.Text = "Send CoT PLI";
            bn_SendCoT_PLI.UseVisualStyleBackColor = true;
            bn_SendCoT_PLI.Click += bn_SendPLI_Click;
            // 
            // rtb_Debug
            // 
            rtb_Debug.Location = new Point(60, 361);
            rtb_Debug.Name = "rtb_Debug";
            rtb_Debug.Size = new Size(686, 312);
            rtb_Debug.TabIndex = 1;
            rtb_Debug.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 251);
            label1.Name = "label1";
            label1.Size = new Size(191, 25);
            label1.TabIndex = 2;
            label1.Text = "Stale Time Delta (mins)";
            // 
            // tb_StaleMinutes
            // 
            tb_StaleMinutes.Location = new Point(266, 245);
            tb_StaleMinutes.Name = "tb_StaleMinutes";
            tb_StaleMinutes.Size = new Size(83, 31);
            tb_StaleMinutes.TabIndex = 3;
            tb_StaleMinutes.Text = "60";
            tb_StaleMinutes.TextAlign = HorizontalAlignment.Right;
            // 
            // tree_Xml
            // 
            tree_Xml.Location = new Point(69, 703);
            tree_Xml.Name = "tree_Xml";
            tree_Xml.Size = new Size(182, 146);
            tree_Xml.TabIndex = 4;
            // 
            // bn_Quit
            // 
            bn_Quit.Location = new Point(781, 211);
            bn_Quit.Name = "bn_Quit";
            bn_Quit.Size = new Size(113, 104);
            bn_Quit.TabIndex = 5;
            bn_Quit.Text = "Quit";
            bn_Quit.UseVisualStyleBackColor = true;
            bn_Quit.Click += bn_Quit_Click;
            // 
            // bn_Clear
            // 
            bn_Clear.Location = new Point(60, 321);
            bn_Clear.Name = "bn_Clear";
            bn_Clear.Size = new Size(112, 34);
            bn_Clear.TabIndex = 6;
            bn_Clear.Text = "Clear";
            bn_Clear.UseVisualStyleBackColor = true;
            bn_Clear.Click += bn_Clear_Click;
            // 
            // cb_Team
            // 
            cb_Team.FormattingEnabled = true;
            cb_Team.Items.AddRange(new object[] { "Cyan", "Red", "White", "Blue", "Magenta", "Brown", "Flint" });
            cb_Team.Location = new Point(688, 757);
            cb_Team.Name = "cb_Team";
            cb_Team.Size = new Size(182, 33);
            cb_Team.TabIndex = 8;
            cb_Team.Text = "Cyan";
            // 
            // bn_SendCoT2
            // 
            bn_SendCoT2.Location = new Point(275, 155);
            bn_SendCoT2.Name = "bn_SendCoT2";
            bn_SendCoT2.Size = new Size(112, 34);
            bn_SendCoT2.TabIndex = 9;
            bn_SendCoT2.Text = "Send CoT 2";
            bn_SendCoT2.UseVisualStyleBackColor = true;
            bn_SendCoT2.Click += bn_SendCoT2_Click;
            // 
            // BN_SendContact
            // 
            BN_SendContact.Location = new Point(421, 177);
            BN_SendContact.Name = "BN_SendContact";
            BN_SendContact.Size = new Size(193, 34);
            BN_SendContact.TabIndex = 10;
            BN_SendContact.Text = "Send Contact";
            BN_SendContact.UseVisualStyleBackColor = true;
            BN_SendContact.Click += BN_SendContact_Click;
            // 
            // BN_Listen
            // 
            BN_Listen.Location = new Point(439, 229);
            BN_Listen.Name = "BN_Listen";
            BN_Listen.Size = new Size(112, 34);
            BN_Listen.TabIndex = 11;
            BN_Listen.Text = "Listen";
            BN_Listen.UseVisualStyleBackColor = true;
            BN_Listen.Click += BN_Listen_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TB_Port);
            groupBox1.Controls.Add(TB_IP);
            groupBox1.Location = new Point(51, 21);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(300, 98);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "CoT IP: Port";
            // 
            // TB_IP
            // 
            TB_IP.Location = new Point(18, 38);
            TB_IP.Name = "TB_IP";
            TB_IP.Size = new Size(128, 31);
            TB_IP.TabIndex = 0;
            TB_IP.Text = "239.2.3.1";
            // 
            // TB_Port
            // 
            TB_Port.Location = new Point(172, 38);
            TB_Port.Name = "TB_Port";
            TB_Port.Size = new Size(63, 31);
            TB_Port.TabIndex = 1;
            TB_Port.Text = "6969";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 878);
            Controls.Add(groupBox1);
            Controls.Add(BN_Listen);
            Controls.Add(BN_SendContact);
            Controls.Add(bn_SendCoT2);
            Controls.Add(cb_Team);
            Controls.Add(bn_Clear);
            Controls.Add(bn_Quit);
            Controls.Add(tree_Xml);
            Controls.Add(tb_StaleMinutes);
            Controls.Add(label1);
            Controls.Add(rtb_Debug);
            Controls.Add(bn_SendCoT_PLI);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "CoT Sim - 9 Oct 2023";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bn_SendCoT_PLI;
        private RichTextBox rtb_Debug;
        private Label label1;
        private TextBox tb_StaleMinutes;
        private TreeView tree_Xml;
        private Button bn_Quit;
        private Button bn_Clear;
        private ComboBox cb_Team;
        private Button bn_SendCoT2;
        private Button BN_SendContact;
        private Button BN_Listen;
        private GroupBox groupBox1;
        private TextBox TB_Port;
        private TextBox TB_IP;
    }
}