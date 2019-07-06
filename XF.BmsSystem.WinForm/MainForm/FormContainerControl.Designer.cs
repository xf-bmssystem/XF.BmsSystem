namespace XF.BmsSystem.WinForm.MainForm
{
    partial class FormContainerControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuList = new DevExpress.XtraBars.Navigation.AccordionControl();
            ((System.ComponentModel.ISupportInitialize)(this.MenuList)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuList
            // 
            this.MenuList.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuList.Location = new System.Drawing.Point(0, 0);
            this.MenuList.Margin = new System.Windows.Forms.Padding(2);
            this.MenuList.Name = "MenuList";
            this.MenuList.OptionsMinimizing.NormalWidth = 202;
            this.MenuList.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.MenuList.Size = new System.Drawing.Size(202, 656);
            this.MenuList.TabIndex = 2;
            this.MenuList.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // FormContainerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MenuList);
            this.Name = "FormContainerControl";
            this.Size = new System.Drawing.Size(918, 656);
            ((System.ComponentModel.ISupportInitialize)(this.MenuList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.AccordionControl MenuList;
    }
}
