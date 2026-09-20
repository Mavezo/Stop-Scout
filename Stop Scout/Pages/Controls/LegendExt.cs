using Syncfusion.Maui.Toolkit.Charts;

namespace Stop_Scout.Pages.Controls
{
	public class LegendExt : ChartLegend
	{
		protected override double GetMaximumSizeCoefficient()
		{
			return 0.5;
		}
	}
}
