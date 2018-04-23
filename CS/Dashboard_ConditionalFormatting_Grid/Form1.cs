using DevExpress.DashboardCommon;

namespace Grid_ExpressionCondition {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        public Form1() {
            InitializeComponent();
            Dashboard dashboard = new Dashboard(); dashboard.LoadFromXml(@"..\..\Data\Dashboard.xml");
            dashboardViewer1.Dashboard = dashboard;
            GridDashboardItem grid = (GridDashboardItem)dashboard.Items["gridDashboardItem1"];
            GridMeasureColumn extendedPrice = (GridMeasureColumn)grid.Columns[1];
            extendedPrice.Measure.UniqueId = "extendedPrice";

            DashboardParameter priceParameter = new DashboardParameter();
            priceParameter.LookUpSettings = null;
            priceParameter.Name = "priceParameter";
            priceParameter.Type = typeof(decimal);
            priceParameter.Value = 150000;
            priceParameter.Description = "Format values that are greater than";
            dashboard.Parameters.Add(priceParameter);

            GridItemFormatRule greaterThanRule = new GridItemFormatRule(extendedPrice);
            FormatConditionExpression greaterThanCondition = new FormatConditionExpression();
            greaterThanCondition.Expression = "extendedPrice > [Parameters.priceParameter]";
            greaterThanCondition.StyleSettings = 
                new AppearanceSettings(FormatConditionAppearanceType.PaleGreen);
            greaterThanRule.ApplyToRow = true;
            greaterThanRule.Condition = greaterThanCondition;

            grid.FormatRules.AddRange(greaterThanRule);
        }
    }
}
