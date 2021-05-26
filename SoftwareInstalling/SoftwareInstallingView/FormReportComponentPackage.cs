using System;
using System.Windows.Forms;
using SoftwareInstallingBuisnessLogic.BuisnessLogics;
using SoftwareInstallingBuisnessLogic.BindingModels;
using SoftwareInstallingBuisnessLogic.ViewModels;
using System.Reflection;
using System.Collections.Generic;

namespace SoftwareInstallingView
{
    public partial class FormReportComponentPackage : Form
    {

        private readonly ReportLogic logic;

        public FormReportComponentPackage(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormReportPackageComponents_Load(object sender, EventArgs e)
        {
            try
            {
                MethodInfo method = logic.GetType().GetMethod("GetComponentPackage");
                List<ReportComponentPackageViewModel> dict = (List<ReportComponentPackageViewModel>)
                    method.Invoke(logic, new object[] { });
                if (dict != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        dataGridView.Rows.Add(new object[] { elem.PackageName, "", "" });
                        foreach (var listElem in elem.Components)
                        {
                            dataGridView.Rows.Add(new object[] { "", listElem.Item1, listElem.Item2 });
                        }
                        dataGridView.Rows.Add(new object[] { "Итого", "", elem.TotalCount });
                        dataGridView.Rows.Add(new object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void ButtonSaveToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        MethodInfo method = logic.GetType().GetMethod("SaveComponentPackageToExcelFile");
                        method.Invoke(logic, new object[] { new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        }});
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
