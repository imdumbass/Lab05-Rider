using Lab05;

class Program {
	public static DateTime generateRandomDate() {
		Random random = new Random();
		DateTime start = new DateTime(2010, 1, 1);
		int range = (DateTime.Today - start).Days;
        
		int randomHour = random.Next(0, 24);
		int randomMinute = random.Next(0, 60);
		int randomSecond = random.Next(0, 60);

		var randomDate = start.AddDays(random.Next(range));

		return new DateTime(randomDate.Year, randomDate.Month, randomDate.Day, randomHour, randomMinute, randomSecond);
	}
	
	public static void Main(string[] args) {
		AutomaticTelephoneExchange automaticTelephoneExchange =
			new AutomaticTelephoneExchange(
				companyName: "Presidential Protected Lines"
		);
		
		/* Компания заключает договор с Emmanuel Macron */
		Client emmanuelMacron = new Client(
			name: "Emmanuel Macron",
			phoneNumber: "+338472956439"
		);
		
		automaticTelephoneExchange
			.clients
			.Add(emmanuelMacron);
		
		/* Клиент осуществляет разговоры */
		emmanuelMacron.calls = new List<Call>() {
			new Call(
				callDuration: 60, 
				number: "+74956046363",
				isOutgoing: true,
				startDate: generateRandomDate()
			),
			
			new Call(
				callDuration: 30, 
				number: "+74956046363",
				isOutgoing: false,
				startDate: generateRandomDate()
			),
			
			new Call(
				callDuration: 360, 
				number: "+74956046363",
				isOutgoing: true,
				startDate: generateRandomDate()
			),
		};
		emmanuelMacron.overdueBillingDays = 10;

		/* Компания заключает договор с Vladimir Putin */
		Client vladimirPutin = new Client(
			name: "Vladimir Putin",
			phoneNumber: "+74956046363"
		);
		automaticTelephoneExchange
			.clients
			.Add(vladimirPutin);
		
		/* Клиент осуществляет разговоры */
		vladimirPutin.calls = new List<Call>() {
			new Call(
				callDuration: 60, 
				number: "+338472956439",
				isOutgoing: false,
				startDate: generateRandomDate()
			),
			
			new Call(
				callDuration: 30, 
				number: "+338472956439",
				isOutgoing: true,
				startDate: generateRandomDate()
			),
			
			new Call(
				callDuration: 360, 
				number: "+338472956439",
				isOutgoing: false,
				startDate: generateRandomDate()
			),
		};
		vladimirPutin.overdueBillingDays = 3;

		
		ATEBill emmanuelMacronBill = AutomaticTelephoneExchange.getBill(emmanuelMacron);
		ATEBill vladimirPutinBill = AutomaticTelephoneExchange.getBill(vladimirPutin);
		
		Console.WriteLine($"[Чек для { emmanuelMacron.name }]");
		Console.WriteLine(emmanuelMacronBill.getPaymentReceipt());
		
		Console.WriteLine($"[Чек для { vladimirPutin.name }]");
		Console.WriteLine(vladimirPutinBill.getPaymentReceipt());
	}
}