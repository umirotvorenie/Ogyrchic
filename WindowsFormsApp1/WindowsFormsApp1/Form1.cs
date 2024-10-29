using System;
using System.Management;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AIDA8 : Form
    {
        public string zhelezo;

        public AIDA8()
        {
            InitializeComponent();
            Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var config in new ManagementObjectSearcher($"select * from {zhelezo}").Get())
                {
                    label1.Text = "Название: " + (string)config["Name"];

                    if (comboBox1.Text == "Процессор")
                    {
                        NameObject.Text = "Характеристики процессора:";
                        label2.Text = "Производитель: " + config["Manufacturer"];
                        label3.Text = "Количество ядер: " + (UInt32)config["NumberOfCores"];
                        label4.Text = "Количество потоков: " + (UInt32)config["ThreadCount"];

                    }
                    else if (comboBox1.Text == "Материнская плата")
                    {
                        NameObject.Text = "Характеристики материнской платы: ";
                        label2.Text = "Тип системной шины: " + config["PrimaryBusType"];
                        label3.Text = "Тип вторичной шины: " + config["SecondaryBusType"];
                        label4.Text = "Имя системы: " + config["SystemName"];

                    }
                    else if (comboBox1.Text == "Оперативная память")
                    {
                        NameObject.Text = "Характеристики оперативной памяти: ";
                        label2.Text = "Номер слота: " + config["BankLabel"];
                        label3.Text = "Частота: " + config["ConfiguredClockSpeed"];
                        label4.Text = "Вольты: " + config["ConfiguredVoltage"];
                        label5.Text = "Производитель: " + config["Manufacturer"];
                    }
                    else if (comboBox1.Text == "Накопитель")
                    {
                        NameObject.Text = "Характеристики накопителя: ";
                        label2.Text = "Модель: " + config["Model"];
                        label3.Text = "Тип интерфейса: " + config["InterfaceType"];
                        label4.Text = "Размер сектора: " + config["BytesPerSector"];
                    }
                    else if (comboBox1.Text == "Видеокарта")
                    {
                        NameObject.Text = "Характеристики видеокарты: ";
                        label2.Text = "Производитель: " + config["AdapterCompatibility"];
                        label3.Text = "Тип DAC: " + config["AdapterDACType"];
                        label4.Text = "Версия драйвера: " + config["DriverVersion"];
                    }
                    else if (comboBox1.Text == "Биос")
                    {
                        NameObject.Text = "Характеристики биоса: ";
                        label2.Text = "Версия биоса: " + config["BIOSVersion"];
                        label3.Text = "Производитель: " + config["Manufacturer"];
                        label4.Text = "Дата выхода: " + config["ReleaseDate"];
                    }
                }

            }
            catch
            {
                MessageBox.Show("Комплектующее не было найдено");
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string coll = comboBox1.Text;
            switch (coll)
            {
                case "Процессор":
                    zhelezo = "Win32_Processor";
                    break;

                case "Материнская плата":
                    zhelezo = "Win32_MotherboardDevice";
                    break;
                case "Оперативная память":
                    zhelezo = "Win32_PhysicalMemory";
                    break;
                case "Накопитель":
                    zhelezo = "Win32_DiskDrive";
                    break;
                case "Видеокарта":
                    zhelezo = "Win32_VideoController";
                    break;
                case "Биос":
                    zhelezo = "Win32_BIOS";
                    break;
            }
            Clear();

        }

        public void Clear()
        {
            label1.Text = " ";
            label2.Text = " ";
            label3.Text = " ";
            label4.Text = " ";
            label5.Text = " ";
            NameObject.Text = " ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}