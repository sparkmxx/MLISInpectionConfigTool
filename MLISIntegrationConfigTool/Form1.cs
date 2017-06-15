using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MLISIntegrationConfigTool
{
    public partial class Form1 : Form
    {
        private static Dictionary<string, string> _configs = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            





            #region 加载配置类

            var assembly = Assembly.LoadFrom(@"G:\starmao\project\vsproject\MLISIntegrationConfigTool\MLISIntegrationConfigTool\bin\Debug\dll\RedNoble.Inspection.Core.dll");
            var types = assembly.GetExportedTypes().Where(p => p.BaseType != null && p.BaseType.Name.StartsWith("FullAuditedAggregateRoot"));
            cbbLoadClass.DataSource = types.Select(p => new { code = p.Name, value = p }).ToList();
            cbbLoadClass.DisplayMember = "code";
            cbbLoadClass.ValueMember = "value";
            cbbLoadClass.SelectedIndexChanged += cbbLoadClass_SelectedIndexChanged;
            #endregion

        }

        private void Combox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboxs = panel5.Controls.Cast<ComboBox>().ToList();

            if (comboxs.Count(p => !p.SelectedValue.Equals("请选择")) > 1)
            {
                MessageBox.Show("只能选择一个");
                comboxs.ForEach(p => p.SelectedIndex = 0);
            }
        }

     

        private static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
                return true;

            foreach (var interfaceType in givenType.GetInterfaces())
                if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == genericType)
                    return true;

            if (givenType.BaseType == null)
                return false;

            return IsAssignableToGenericType(givenType.BaseType, genericType);
        }
        private static bool IsPrimitiveExtended(Type type)
        {
            if (type.IsPrimitive)
                return true;

            return type == typeof(string) ||
                   type == typeof(decimal) ||
                   type == typeof(DateTime) ||
                   type == typeof(DateTimeOffset) ||
                   type == typeof(TimeSpan) ||
                   type == typeof(Guid);
        }

        private void btnAddRelation_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node == null)
            {
                MessageBox.Show("选择一个属性");
                return;
            }

            var comboxs = panel5.Controls.Cast<ComboBox>().ToList();
            var selectedCombox = comboxs.FirstOrDefault(p => !p.SelectedValue.Equals("请选择"));
            if (selectedCombox == null)
            {
                MessageBox.Show("选择一个对应属性");
                return;
            }
            var fromValue = node.FullPath.Replace("\\", ".");
            var toValue = $"{selectedCombox.Name}.{selectedCombox.SelectedValue}";
            if (_configs.ContainsKey(node.Text))
            {
                _configs[fromValue] = toValue;
            }
            else
            {
                _configs.Add(fromValue, toValue);
            }

        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            if (_configs.Count == 0)
            {
                MessageBox.Show("请先添加对应关系再保存配置");
                return;
            }

            List<dynamic> result = new List<dynamic>();

            foreach (var config in _configs)
            {
                result.Add(new { from = config.Key, to = config.Value });
            }

            var jsonStr = JsonConvert.SerializeObject(result);
        }

        private void btnExcuteProcedure_Click(object sender, EventArgs e)
        {
            List<DataTable> dts = new List<DataTable>();
            if (string.IsNullOrEmpty(txtProcedure.Text))
            {
                MessageBox.Show("请填写执行存储过程sql");
                return;
            }

            #region 测试数据

            try
            {
                IDbConnection conn = new SqlConnection("Data Source=183.194.100.138; Database=RedNobleInspection; User ID=sa; Password=!@#$%qwert12345; MultipleActiveResultSets=True;");
                var query = conn.QueryMultiple(sql: txtProcedure.Text);
                while (!query.IsConsumed)
                {

                    DataGridView grid = new DataGridView() { Name = Guid.NewGuid().ToString("N"), Dock = DockStyle.Top, Height = 75 };
                    var dt = query.Read().ToDataTable();
                    grid.DataSource = dt;
                    dts.Add(dt);
                    panel1.Controls.Add(grid);
                }
                conn.Close();
                //清空
                panel5.Controls.Clear();
                
                if (dts.Count > 0)
                {
                    var n = 0;
                    foreach (var dataTable in dts)
                    {
                        ComboBox combox = new ComboBox()
                        {
                            Name = $"T{n}",
                            Size = new Size(100, 20),
                            Location = new Point(0, 30 * n)
                        };
                        var list = dataTable.Columns.Cast<DataColumn>().Select(p => p.Caption).ToList();
                        list.Reverse();
                        list.Add("请选择");
                        list.Reverse();
                        combox.DataSource = list;
                        panel5.Controls.Add(combox);

                        combox.SelectedIndexChanged += Combox_SelectedIndexChanged;
                        n++;

                        
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                
            }
           

            #endregion
        }

        private void cbbLoadClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 加载需要配置的类

            var type = cbbLoadClass.SelectedValue as Type;
            if (type == null)
            {
                MessageBox.Show("未能加载类");
                return;
            }
            treeView1.Nodes.Clear();
            var rootNode = treeView1.Nodes.Add(type.Name);
            AddNodes(type, rootNode);
            treeView1.ExpandAll();

            #endregion
        }

        private void AddNodes(Type inType, TreeNode node,List<Type> existTypes=null)
        {
            if(existTypes==null) existTypes =new List<Type>();
            existTypes.Add(inType);

            foreach (var propertyInfo in inType.GetProperties())
            {
                var nestedNode = node.Nodes.Add(propertyInfo.Name);
                var type = propertyInfo.PropertyType;
                if ((type.IsClass) && !IsPrimitiveExtended(type))
                {
                    if (IsAssignableToGenericType(type, typeof(IEnumerable<>)))
                    {
                        if (!existTypes.Contains(type.GetGenericArguments()[0]))
                        {
                            AddNodes(type.GetGenericArguments()[0], nestedNode, existTypes);
                        }
                        
                    }
                    else
                    {
                        
                        if (!existTypes.Contains(type))
                        {
                            AddNodes(type, nestedNode, existTypes);
                        }
                    }

                }
            }
        }
    }

    public static class Extentions
    {
        public static DataTable ToDataTable(this IEnumerable<dynamic> items)
        {
            var data = items.ToArray();
            if (!data.Any()) return null;

            var dt = new DataTable();
            foreach (var key in ((IDictionary<string, object>)data[0]).Keys)
            {
                dt.Columns.Add(key);
            }
            foreach (var d in data)
            {
                dt.Rows.Add(((IDictionary<string, object>)d).Values.ToArray());
            }
            return dt;
        }
    }

    public interface ISpecimenIntegration
    {
        void Store(StoreInput input);
    }

    public class StoreInput
    {
        public string Barcode { get; set; }
    }

    public class Specimen
    {

        public string Barcode { get; set; }

        public string SpecimenTypeCode { get; set; }

        public string SpecimenTypeName { get; set; }

        public Patient Patient { get; set; }

        public List<SpecimenInspectItem> SpecimenInspectItems { get; set; }
    }

    public class Patient
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }


    public class SpecimenInspectItem
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
