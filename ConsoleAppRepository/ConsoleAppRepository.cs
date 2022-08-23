namespace ConsoleAppRepository;

public class DeliveryRepository
{

    protected readonly List<DeliveryInfo> _info = new List<DeliveryInfo>();

    public bool AddNewOrder(DeliveryInfo item)
    {
        int prevCount = _info.Count;

        _info.Add(item);

        return prevCount < _info.Count ? true : false;
    }

    public List<DeliveryInfo> ResearchItem()
    {
        return _info;
    }

    public bool UpdateStatus(int orderNumber, DeliveryInfo newInfo)
    {
        DeliveryInfo oldInfo = _info.Find(item => item.OrderNumber == orderNumber);

        if (oldInfo != null)
        {
            oldInfo.OrderNumber = newInfo.OrderNumber != 0 ? newInfo.OrderNumber : oldInfo.OrderNumber;

            oldInfo.OrderDate = newInfo.OrderDate != "" ? newInfo.OrderDate : oldInfo.OrderDate;

            oldInfo.DeliveryDate = newInfo.DeliveryDate != "" ? newInfo.DeliveryDate : oldInfo.DeliveryDate;

            oldInfo.OrderStatus = newInfo.OrderStatus != 0 ? newInfo.OrderStatus : oldInfo.OrderStatus;

            oldInfo.ItemQuantity = newInfo.ItemQuantity != 0 ? newInfo.ItemQuantity : oldInfo.ItemQuantity;

           oldInfo.CustomerID = newInfo.CustomerID != 0 ? newInfo.CustomerID : oldInfo.CustomerID;

            oldInfo.ItemName = newInfo.ItemName != "" ? newInfo.ItemName : oldInfo.ItemName;



            return true;
        }
        else
        {
            return false;
        }
    }
    public bool DeleteItem(int itemNumber)
    {
        DeliveryInfo itemToDelete = _info.Find(item => item.OrderNumber == itemNumber);

        bool deleteResult = _info.Remove(itemToDelete);

        return deleteResult;
    }
}