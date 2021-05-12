﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using SoftwareInstallingBuisnessLogic.BuisnessLogics;
using SoftwareInstallingBuisnessLogic.ViewModels;
using SoftwareInstallingBuisnessLogic.BindingModels;
using System.Windows.Forms;

namespace SoftwareInstallingView
{
    public partial class FormMails : Form
    {
        private readonly MailLogic logic;

        private PageViewModel pageViewModel;

        public FormMails(MailLogic mailLogic)
        {
            logic = mailLogic;
            InitializeComponent();
        }

        private void FormMails_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData(int page = 1)
        {
            int pageSize = 17; // Количество элементов на странице

            var list = logic.GetMessagesForPage(new MessageInfoBindingModel 
            {
                Page = page,
                PageSize = pageSize
            });
            if (list != null)
            {
                pageViewModel = new PageViewModel(logic.Count(), page, pageSize, list);

                dataGridView.DataSource = pageViewModel.Messages;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (pageViewModel.HasNextPage)
            {
                LoadData(pageViewModel.PageNumber + 1);
            }
            else
            {
                MessageBox.Show("Это последняя страница", "Упс", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (pageViewModel.HasPreviousPage)
            {
                LoadData(pageViewModel.PageNumber - 1);
            }
            else
            {
                MessageBox.Show("Это первая страница", "Упс", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
