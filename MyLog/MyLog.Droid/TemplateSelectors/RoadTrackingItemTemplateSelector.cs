using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;
using MyLog.Core.ViewModels.RoadTracking;

namespace MyLog.Droid.TemplateSelectors
{
    public class RoadTrackingItemTemplateSelector : MvxTemplateSelector<BaseItemViewModel>
    {
        public override int GetItemLayoutId(int fromViewType)
        {
            switch ((ViewType) fromViewType)
            {
                case ViewType.Way:
                    return Resource.Layout.item_way;
                case ViewType.WayPoint:
                    return Resource.Layout.item_way_point;
                default:
                    return 0;
            }
        }

        protected override int SelectItemViewType(BaseItemViewModel forItemObject) => (int) GetViewType(forItemObject);

        private ViewType GetViewType(BaseItemViewModel item)
        {
            switch (item)
            {
                case WaypointItemViewModel _:
                    return ViewType.WayPoint;
                case WayItemViewModel _:
                    return ViewType.Way;
                default:
                    return ViewType.Default;
            }
        }

        private enum ViewType
        {
            Default,
            WayPoint,
            Way
        }
    }
}