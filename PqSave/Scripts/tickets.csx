PrintTickets();
Console.WriteLine("Setting new ticket count");
Save.misc.fsGiftTicketNum = 20000;
PrintTickets();

void PrintTickets()
{
    Console.WriteLine($"You have {Save.misc.fsGiftTicketNum} tickets");
}
