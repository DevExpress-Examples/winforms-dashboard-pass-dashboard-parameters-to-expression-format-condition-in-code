Imports DevExpress.DashboardCommon

Namespace Grid_ExpressionCondition
    Partial Public Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Public Sub New()
            InitializeComponent()
            Dim dashboard As New Dashboard()
            dashboard.LoadFromXml("..\..\Data\Dashboard.xml")
            dashboardViewer1.Dashboard = dashboard
            Dim grid As GridDashboardItem =
                CType(dashboard.Items("gridDashboardItem1"), GridDashboardItem)
            Dim extendedPrice As GridMeasureColumn = CType(grid.Columns(1), GridMeasureColumn)
            extendedPrice.Measure.UniqueId = "extendedPrice"

            Dim priceParameter As New DashboardParameter()
            priceParameter.LookUpSettings = Nothing
            priceParameter.Name = "priceParameter"
            priceParameter.Type = GetType(Decimal)
            priceParameter.Value = 150000
            priceParameter.Description = "Format values that are greater than"
            dashboard.Parameters.Add(priceParameter)

            Dim greaterThanRule As New GridItemFormatRule(extendedPrice)
            Dim greaterThanCondition As New FormatConditionExpression()
            greaterThanCondition.Expression = "extendedPrice > [Parameters.priceParameter]"
            greaterThanCondition.StyleSettings =
                New AppearanceSettings(FormatConditionAppearanceType.PaleGreen)
            greaterThanRule.ApplyToRow = True
            greaterThanRule.Condition = greaterThanCondition

            grid.FormatRules.AddRange(greaterThanRule)
        End Sub
    End Class
End Namespace
