namespace Lab05; 

public class ATEBill {
	public static readonly byte centsPerSecond = 3;
	public double penaltyRate { get; } = 0.01;     /* Штрафная ставка */
	public Client client { get; }          /* Текущий клиент */

	public string getPaymentReceipt() {
		string paymentReceipt = new string('=', 45);
		paymentReceipt += '\n';
		
		uint callDurationSum = 0;
		UInt32 needToPay = 0;
		
		foreach (var (call, index) in client.calls.WithIndex()) {
			callDurationSum += call.callDuration;
			
			paymentReceipt += $"""
			[Звонок №{ index + 1 }]
			Номер: { call.number } 
			Дата: { call.startDate.ToString() } 
			Длительность звонка в секундах: { call.callDuration }
			Тип звонка: { (call.isOutgoing ? "Исходящий" : "Входящий" ) } 
			""";

			// Плата только за исходящие звонки
			if (call.isOutgoing) {
				needToPay += call.callDuration * centsPerSecond;
			}
			
			paymentReceipt += "\n\n";
		}

		double fine = ((double)needToPay * penaltyRate) * (double)client.overdueBillingDays;

		paymentReceipt += $"""
		[Сводка:]
		Имя: { client.name }
		Номер телефона: { client.phoneNumber }
		Средняя продолжительность вызова: { (client.calls.Count > 0 ? (uint)(callDurationSum / client.calls.Count) : 0) }
		Просрочено дней оплаты: { client.overdueBillingDays }
		Штраф: { fine } у.е.
		К оплате: { (double)needToPay + fine } у.е.
		""";
		paymentReceipt += '\n';
		paymentReceipt += new string('=', 45);
		paymentReceipt += "\n\n";
		
		return paymentReceipt;
	}
	
	public ATEBill(Client client) {
		this.client = client;
	}
}