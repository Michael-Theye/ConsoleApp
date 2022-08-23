namespace ConsoleAppRepository;

public class DeliveryInfo {
    public DeliveryInfo() {}

    public DeliveryInfo(int orderNumber, string orderDate, string deliveryDate, OrderStatus orderStatus,  int itemQuantity, int customerID, string itemName){           
        OrderNumber = orderNumber;
        OrderDate = orderDate;
        DeliveryDate =  deliveryDate;
        OrderStatus = orderStatus;
        ItemQuantity = itemQuantity;
        CustomerID = customerID;
        ItemName = itemName;
    }
    public int OrderNumber {get; set;}
    public string OrderDate {get; set;}

    public string DeliveryDate {get; set;}

    public OrderStatus OrderStatus {get; set;}

    
    
    public int ItemQuantity {get; set;}

    public int CustomerID {get; set;}

    public string ItemName {get; set;}

}

public enum OrderStatus{Scheduled, EnRoute, Complete, Cancelled}