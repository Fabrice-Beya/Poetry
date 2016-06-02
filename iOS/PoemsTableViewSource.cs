using System;
using UIKit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poetry.iOS
{
	public class PoemsTableViewSource:UITableViewSource
	{
		
		PoetryService db;
		List<Poem> Poems;
		public PoemsTableViewSource()
		{
			db = new PoetryService();
			GetPoems();
		}

		public async Task GetPoems()
		{
			Poems = await db.GetPoems();
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

		public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			
			tableView.DeselectRow(indexPath, true);

		}

		public Poem GetPoem(int index)
		{
			return Poems[index];
		}
	}
}

