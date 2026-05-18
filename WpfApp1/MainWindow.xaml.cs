using SMMPI.Infrastructure.Plugins.Tools;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string slnRoot;
        string packageDir;
        string exePath;
        string outputdir;
        string token;
        string serverid;
        string channel;
        string formattedDate;

        public MainWindow()
        {
            InitializeComponent();
            slnRoot = SolutionRoot.Get();
            packageDir = System.IO.Path.Combine(slnRoot, "Packages", "DiscordChatExporter");
            outputdir = System.IO.Path.Combine(slnRoot, "Output");
            exePath = System.IO.Path.Combine(packageDir, "DiscordChatExporter.Cli.exe");

            cbbFormat.ItemsSource = new string[] { "PlainText", "HtmlDark", "HtmlLight", "Csv", "Json" };
            txtConsole.Text += "\n";
            formattedDate = dtpTime.SelectedDate.Value.ToString("MM/dd/yyyy");
        }

        private void AppendConsole(string text)
        {
            Dispatcher.Invoke(() =>
            {
                txtConsole.AppendText(text + Environment.NewLine);
                txtConsole.ScrollToEnd();
            });
        }


        private void toggleVisibility()
        {

            ExportGroup.Visibility = ExportGroup.Visibility == Visibility.Visible ? ExportGroup.Visibility = Visibility.Hidden : ExportGroup.Visibility = Visibility.Visible;
        }

        private async void btnDms(object sender, RoutedEventArgs e)
        {
            txtConsole.Clear();
            try
            {
                await ProcessHandler.RunProcessCheckedAsync(
                    exePath,
                    $"dm -t {token}",
                    packageDir,
                    AppendConsole
                );
            }
            catch (Exception ex)
            {
                AppendConsole("[exception] " + ex.Message);
            }
        }

        private async void btnChannels(object sender, RoutedEventArgs e)
        {
            txtConsole.Clear();
            try
            {
                await ProcessHandler.RunProcessCheckedAsync(
                    exePath,
                    $"channels -g {serverid} -t {token}",
                    packageDir,
                    AppendConsole
                );
            }
            catch (Exception ex)
            {
                AppendConsole("[exception] " + ex.Message);
            }
        }

        private async void btnExportAll()
        {
            txtConsole.Clear();
            try
            {
                await ProcessHandler.RunProcessCheckedAsync(
                    exePath,
                    $"exportall -t {token} -f {cbbFormat.SelectedValue} -o {outputdir} --after {formattedDate}",
                    packageDir,
                    AppendConsole
                );
            }
            catch (Exception ex)
            {
                AppendConsole("[exception] " + ex.Message);
            }
        }

        private async void btnExport(object sender, RoutedEventArgs e)
        {
            txtConsole.Clear();
            if (chkExportAll.IsChecked == true)
            {
                btnExportAll();
                return;
            }
            try
            {
                await ProcessHandler.RunProcessCheckedAsync(
                    exePath,
                    $"export -t {token} -f {cbbFormat.SelectedValue} -c {channel} -o {outputdir} --after {formattedDate}",
                    packageDir,
                    AppendConsole
                );
            }
            catch (Exception ex)
            {
                AppendConsole("[exception] " + ex.Message);
            }
        }

        private void txtToken_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            token = txtToken.Text;
        }

        private async void btnOutput(object sender, RoutedEventArgs e)
        {
            await ProcessHandler.TryRunProcessAsync("explorer.exe", outputdir, slnRoot);
        }

        private void btnAuth(object sender, RoutedEventArgs e)
        {
            toggleVisibility();
        }

        private void txtChannel_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            channel = txtChannel.Text;
        }

        private void txtServer_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            serverid = txtServer.Text;
        }

        private void DtpTime_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DatePicker dp = (DatePicker)sender;

            if (dp.SelectedDate.HasValue)
            {
                formattedDate = dp.SelectedDate.Value.ToString("MM/dd/yyyy");
            }
        }
    }
}