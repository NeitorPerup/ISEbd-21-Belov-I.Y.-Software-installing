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

        private IndexViewModel index;

        public FormMails(MailLogic mailLogic)
        {
            logic = mailLogic;
            index = new IndexViewModel();
            InitializeComponent();
        }

        private void FormMails_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData(int page = 1)
        {
            int pageSize = 17; // Количество элементов на странице

            var list = logic.Read(null);
            if (list != null)
            {
                index.PageViewModel = new PageViewModel(list.Count, page, pageSize);
                index.Messages = list.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                dataGridView.DataSource = index.Messages;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (index.PageViewModel.HasNextPage)
            {
                LoadData(index.PageViewModel.PageNumber + 1);
            }
            else
            {
                MessageBox.Show("Это последняя страница", "Упс", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (index.PageViewModel.HasPreviousPage)
            {
                LoadData(index.PageViewModel.PageNumber - 1);
            }
            else
            {
                MessageBox.Show("Это первая страница", "Упс", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
