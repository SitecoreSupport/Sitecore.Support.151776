using Sitecore.Data.Items;
using Sitecore.Pipelines.ItemProvider.GetItem;

namespace Sitecore.Support.Pipelines.ItemProvider.GetItem
{
  public class DisableEnforcingVersionPresenceForExperienceEditor : GetItemProcessor
  {
    public override void Process(GetItemArgs args)
    {
      if (Sitecore.Context.Site != null && Sitecore.Context.PageMode.IsExperienceEditor)
      {
        if (args != null && args.Result == null && args.Language != null && args.Version != null && args.Database != null)
        {
          Item item = null;
          if ((object)args.ItemId != null)
          {
            item = args.FallbackProvider.GetItem(args.ItemId, args.Language, args.Version, args.Database, args.SecurityCheck);
          }
          else if (!string.IsNullOrWhiteSpace(args.ItemPath))
          {
            item = args.FallbackProvider.GetItem(args.ItemPath, args.Language, args.Version, args.Database, args.SecurityCheck);
          }
          args.Result = item;
        }
      }      
    }
  }
}