using System;
using UIKit;
using System.Collections.Generic;

namespace Poetry.iOS
{
	public class PoemsTableViewSource:UITableViewSource
	{
		DataSource db;
		List<Poem> Poems;
		public PoemsTableViewSource()
		{
			db = new DataSource();
			Poems = db.GetItems();
		}

		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(new Foundation.NSString("PoemCell")) as UITableViewCell;

			if (cell == null)
			{
				cell = new UITableViewCell();
			}
			cell.TextLabel.TextAlignment = UITextAlignment.Center;
			cell.TextLabel.Text = Poems[indexPath.Row].Title;

			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return Poems.Count;
		}
	}
}

