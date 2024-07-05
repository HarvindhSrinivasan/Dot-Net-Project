public partial class MainForm : Form
{
    private readonly SalesService salesService;
    private List<SalesData> salesData;

    public MainForm()
    {
        InitializeComponent();
        var filePath = @"C:\Users\arunb\Documents\SuperstoreForecast\SP_Coding_Exercise_Dataset_(1).xlsx";
        salesService = new SalesService(filePath);
    }

    private void btnGetSales_Click(object sender, EventArgs e)
    {
        int year = int.Parse(txtYear.Text);
        salesData = salesService.GetSalesByYear(year).ToList();
        dataGridView.DataSource = salesData;
    }

    private void btnApplyIncrement_Click(object sender, EventArgs e)
    {
        double percentage = double.Parse(txtPercentage.Text);
        var incrementedSalesData = salesService.ApplyIncrement(salesData, percentage).ToList();
        dataGridView.DataSource = incrementedSalesData;
    }

    private void btnExportCsv_Click(object sender, EventArgs e)
    {
        var exportService = new CsvExportService();
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            exportService.ExportSalesDataToCsv(salesData, saveFileDialog.FileName);
        }
    }
}
