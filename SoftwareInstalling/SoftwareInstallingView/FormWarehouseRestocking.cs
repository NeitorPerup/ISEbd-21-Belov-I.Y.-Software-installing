using System.Collections.Generic;
using SoftwareInstallingBuisnessLogic.ViewModels;
using SoftwareInstallingBuisnessLogic.BuisnessLogics;
using System;
using System.Windows.Forms;
using Unity;
using SoftwareInstallingBuisnessLogic.BindingModels;
using SoftwareInstallingListImplements;
using SoftwareInstallingListImplements.Models;
using System.Linq;

namespace SoftwareInstallingView
{
    public partial class FormWarehouseRestocking : Form
    {
        WarehouseLogic logic;

        private readonly DataListSingleton source;

        WarehouseBindingModel bm = new WarehouseBindingModel();

        public int ComponentId
        {
            get { return Convert.ToInt32(comboBoxComponent.SelectedValue); }
            set { comboBoxComponent.SelectedValue = value; }
        }

        public int WarehouseId
        {
            get { return Convert.ToInt32(comboBoxWarehouse.SelectedValue); }
            set { comboBoxWarehouse.SelectedValue = value; }
        }

        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }

        public FormWarehouseRestocking(ComponentLogic componentlogic, WarehouseLogic warehouseLogic)
        {
            InitializeComponent();
            logic = warehouseLogic;
            source = DataListSingleton.GetInstance();
            List <ComponentViewModel> listComponent = componentlogic.Read(null);
            if (listComponent != null)
            {
                comboBoxComponent.DisplayMember = "ComponentName";
                comboBoxComponent.ValueMember = "Id";
                comboBoxComponent.DataSource = listComponent;
                comboBoxComponent.SelectedItem = null;
            }

            List<WarehouseViewModel> listWarehouse = warehouseLogic.Read(null);
            if (listWarehouse != null)
            {
                comboBoxWarehouse.DisplayMember = "WarehouseName";
                comboBoxWarehouse.ValueMember = "Id";
                comboBoxWarehouse.DataSource = listWarehouse;
                comboBoxWarehouse.SelectedItem = null;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxComponent.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (comboBoxWarehouse.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            WarehouseViewModel view = logic.Read(new WarehouseBindingModel
            {
                Id = WarehouseId
            })?[0];

            if (view != null)
            {
                bm.WarehouseComponents = view.WarehouseComponents;
                bm.DateCreate = view.DateCreate;
                bm.Id = view.Id;
                bm.Responsible = view.Responsible;
                bm.WarehouseName = view.WarehouseName;
            }

            if (bm.WarehouseComponents.ContainsKey(ComponentId))
            {
                bm.WarehouseComponents[ComponentId] = (source.Components.FirstOrDefault(rec => rec.Id == ComponentId).ComponentName, Count);
            }
            else
            {
                bm.WarehouseComponents.Add(ComponentId, (source.Components.FirstOrDefault(rec => rec.Id == ComponentId).ComponentName, Count));
            }
            logic.CreateOrUpdate(bm);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
