﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portals.MetadataTranslationManager.Controls
{
    public partial class MenuControl : UserControl
    {
        public event EventHandler ButtonCloseClicked;
        public event EventHandler ButtonLoadEnvironmentClicked;
        public event EventHandler ButtonLoadDataClicked;
        public event EventHandler ButtonExportDataClicked;
        public event EventHandler ButtonImportDataClicked;

        public MenuControl()
        {
            InitializeComponent();
            btnImportData.Visible = false;
        }

        protected virtual void OnButtonCloseClick(EventArgs e) {
            ButtonCloseClicked?.Invoke(this, e);
        }

        protected virtual void OnButtonLoadEnvironment_Click(EventArgs e)
        {
            ButtonLoadEnvironmentClicked?.Invoke(this, e);
        }

        protected virtual void OnButtonLoadData_Click(EventArgs e)
        {
            ButtonLoadDataClicked?.Invoke(this, e);
        }

        protected virtual void OnButtonExportData_Click(EventArgs e)
        {
            ButtonExportDataClicked?.Invoke(this, e);
        }

        protected virtual void OnButtonImportData_Click(EventArgs e)
        {
            ButtonImportDataClicked?.Invoke(this, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnButtonCloseClick(EventArgs.Empty);
        }

        private void btnLoadEnvironment_Click(object sender, EventArgs e)
        {
            OnButtonLoadEnvironment_Click(EventArgs.Empty);
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            OnButtonLoadData_Click(EventArgs.Empty);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            OnButtonExportData_Click(EventArgs.Empty);
        }

        private void btnImportData_Click(object sender, EventArgs e)
        {
            OnButtonImportData_Click(EventArgs.Empty);
        }
    }
}
