using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Doctor> Doctors { get; set; }
        public ObservableCollection<Service> Services { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Создаем коллекцию услуг и добавляем несколько элементов
            Services = new ObservableCollection<Service>();
            Services.Add(new Service { Name = "Массаж", Price = 1100 });
            Services.Add(new Service { Name = "Водолечебница", Price = 1000 });
            Services.Add(new Service { Name = "Галокамера", Price = 800 });

            Doctors = new ObservableCollection<Doctor>();
            Doctors.Add(new Doctor { FullName = "Иван Иванов", Specialization = "Терапевт" });
            Doctors.Add(new Doctor { FullName = "Петр Петров", Specialization = "Хирург" });

            DataContext = this;
            foreach (var doctor in Doctors)
            {
                Console.WriteLine(doctor.FullName);
            }
        }

        private void servicesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (servicesComboBox.SelectedIndex >= 0)
            {
                // Получаем выбранный элемент
                Service selectedService = (Service)servicesComboBox.SelectedItem;
            }
        }

        private void doctorsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (doctorsComboBox.SelectedIndex >= 0)
            {
                // получаем выбранного врача
                Doctor selectedDoctor = (Doctor)doctorsComboBox.SelectedItem;

                // выводим информацию о выбранном враче
                MessageBox.Show("Выбран врач: " + selectedDoctor.FullName + ", Специализация: " + selectedDoctor.Specialization);
            }
        }
    }

    public class Service
    {
        public string Name { get; set; } = "";
        public int Price { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Doctor
    {
        public string FullName { get; set; } = "";
        public string Specialization { get; set; } = "";

        public override string ToString()
        {
            return FullName;
        }
    }
}

