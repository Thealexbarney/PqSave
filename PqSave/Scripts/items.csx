var items = Save.itemStorage;
short count = 999;

items.SetCount(Item.RedCommon, count);
items.SetCount(Item.RedUnCommon, count);
items.SetCount(Item.BlueCommon, count);
items.SetCount(Item.BlueUnCommon, count);
items.SetCount(Item.YellowCommon, count);
items.SetCount(Item.YellowUnCommon, count);
items.SetCount(Item.GreyCommon, count);
items.SetCount(Item.GreyUnCommon, count);
items.SetCount(Item.Rare, count);
items.SetCount(Item.Legend, count);

static void SetCount(this ItemStorage items, Item type, short count)
{
    var item = items.datas.FirstOrDefault(x => x.id == type);
    if (item == null)
    {
        item = new ItemStorage.Core { id = type, isNew = true };
        items.datas.Add(item);
    }
    item.num = count;
}
