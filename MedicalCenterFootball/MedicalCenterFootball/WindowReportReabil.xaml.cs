using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Word = Microsoft.Office.Interop.Word;
using System.IO;

namespace MedicalCenterFootball
{
    /// <summary>
    /// Логика взаимодействия для WindowReportReabil.xaml
    /// </summary>
    public partial class WindowReportReabil : System.Windows.Window
    {
        private string taskFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Задача реабилитологу.txt");
        public WindowReportReabil()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            DGridReabil.ItemsSource = MedicalCenterEntities.GetContext().RehabTherapistReports.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var application = new Word.Application();
            Word.Document document = application.Documents.Add();

            // Получаем данные из DataGrid
            var reports = DGridReabil.ItemsSource as List<RehabTherapistReports>; // Предполагается, что Employee - это ваш класс модели

            // Добавляем данные в документ
            foreach (var report in reports)
            {
                document.Content.Text += $"Очёт: {report.ReportID}, Игрок: {report.PlayerName}, Тип упражнения: {report.ExerciseType},  Повторения{report.Repetitions}, Замечания{report.Remarks} \n";
            }

            // Сохраняем документ
            string docxPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Отчёт реабилитолога.docx");
            string pdfPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Отчёт реабилитолога.pdf");
            document.SaveAs2(docxPath);
            document.SaveAs2(pdfPath, Word.WdExportFormat.wdExportFormatPDF);

            // Открываем документ для просмотра
            application.Visible = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenOrCreateTaskFile();
        }
        private void OpenOrCreateTaskFile()
        {
            // Проверьте, существует ли файл. Если нет, создайте его.
            if (!File.Exists(taskFilePath))
            {
                File.WriteAllText(taskFilePath, ""); // Создать пустой файл
            }

            // Откройте файл в блокноте
            Process.Start(new ProcessStartInfo("notepad.exe", taskFilePath)
            {
                UseShellExecute = true
            });
        }
    }
}
