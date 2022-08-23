using ConsoleAppRepository;

public class ProgramUI {
    
    DeliveryRepository _repo = new DeliveryRepository();

    public void Run() {
        Seed();
        DeliveryInfo();
    }

    private void DeliveryInfo() {
        bool keepRunning = true;

        while(keepRunning){
            Console.Clear();

    System.Console.WriteLine("Please select from the following options:\n" 
                + "1. Create new order \n"
                + "2. View order items\n"
                + "3. Update order by order number\n"
                + "4. Delete order by order number\n"
                + "5. Exit");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateNewOrder();
                    break;
                case "2":
                    ViewAllOrders();
                    break;
                case "3":
                    UpdateOrder();
                    break;
                case "4":
                    DeleteOrder();
                    break;
                case "5":
                    Console.Clear();
                    System.Console.WriteLine("Have a good day!");

                    keepRunning = false;
                    break;
                    default:
                System.Console.WriteLine("Double check what inputed and try again");
                break;
            }
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();       
        }

    }
    private void CreateNewOrder() {
        Console.Clear();

        DeliveryInfo newOrder = new DeliveryInfo();
 
    newOrder.OrderNumber = _repo.ResearchItem().Count + 1;

    System.Console.WriteLine("What is your Order Number.");
    newOrder.OrderNumber = int.Parse(Console.ReadLine());

    System.Console.WriteLine("What Item are you ordering");
    newOrder.ItemName=(Console.ReadLine());

    System.Console.WriteLine("How many of the items are you ordering");
    newOrder.ItemQuantity= int.Parse(Console.ReadLine());

    System.Console.WriteLine("What is your order date");
    newOrder.OrderDate = (Console.ReadLine());

    System.Console.WriteLine("What is your delivery date");
    newOrder.DeliveryDate = (Console.ReadLine());

    System.Console.WriteLine("What is your Customer ID");
    newOrder.CustomerID = int.Parse(Console.ReadLine());

    System.Console.WriteLine("What status is your package in\n"
    + "Schedule\n"
    + "EnRoute\n"
    + "Complete\n"
    + "Cancelled");
    string orderStatus = Console.ReadLine();

    bool orderAdded = _repo.AddNewOrder(newOrder);

    if(orderAdded){
        Console.Clear();
        System.Console.WriteLine("Order added\n"); 
    } else {
        Console.Clear();
        System.Console.WriteLine("Can't add new order\n");
    }
        
    }       
    private void ViewAllOrders() {
        Console.Clear();
        foreach (DeliveryInfo order in _repo.ResearchItem())
        {
            DisplayOrder(order);
        }
    } 
    private void UpdateOrder() {
        Console.Clear();
        System.Console.WriteLine("Please enter the order number you would like to update");
        int orderNumber = int.Parse(Console.ReadLine());
        DeliveryInfo newOrder = new DeliveryInfo();

        System.Console.WriteLine("Please enter the new item order. If not press enter...");
        newOrder.ItemName = Console.ReadLine();

        System.Console.WriteLine("Please enter the new amount. If not press enter");
        newOrder.ItemQuantity= int.Parse(Console.ReadLine());
    }
    private void DeleteOrder() {
        Console.Clear();
        System.Console.WriteLine("Please enter the order number you want to delete...");
        int orderNumber= int.Parse(Console.ReadLine());

        bool deleteSuccess = _repo.DeleteItem(orderNumber);

        if(deleteSuccess)
        {
            Console.Clear();
            System.Console.WriteLine("Deleted order complete");
        }else{
            Console.Clear();
            System.Console.WriteLine("Order not deleted try again later");
        }
    }
    private void DisplayOrder(DeliveryInfo order){
        System.Console.WriteLine($"Order #{order.OrderNumber}: {order.OrderStatus}\n"
        +"------------------\n"
        +$"{order.DeliveryDate}\n"
        +$"{order.OrderDate}\n"
        +$"{order.ItemName}\n"
        +$"{order.ItemQuantity}\n" 
        +$"{order.CustomerID}\n"
        );

    }
    private void Seed(){
        DeliveryInfo narutoStatue = new DeliveryInfo(_repo.ResearchItem().Count +1, "3/4/2022", "3/19/2022", OrderStatus.Scheduled,  1, 101, "Naruto Statue"); _repo.AddNewOrder(narutoStatue);

         DeliveryInfo amumuHoodie = new DeliveryInfo(_repo.ResearchItem().Count +1, "8/15/2022", "8/20/2022", OrderStatus.EnRoute,  1, 102, "Amumu Hoodie"); _repo.AddNewOrder(amumuHoodie);

        DeliveryInfo riasHat = new DeliveryInfo(_repo.ResearchItem().Count +1, "1/12/2020", "1/2/2020", OrderStatus.Complete,  1, 103, 
        "Rias Hat"); _repo.AddNewOrder(riasHat);

         DeliveryInfo pikachuPants = new DeliveryInfo(_repo.ResearchItem().Count +1, "5/1/2022", "8/20/2022", OrderStatus.Cancelled,  1, 104, "Pikachu Pants"); _repo.AddNewOrder(pikachuPants);
    }
}

