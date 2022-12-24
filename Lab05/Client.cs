namespace Lab05; 

public class Client {
	public string name { get; }
	public string phoneNumber { get; }				
	public List<Call> calls { get; set; }			
	public byte overdueBillingDays { get; set; }    /* Количество просроченных дней */

	public Client(string name, string phoneNumber) {
		this.name = name;
		this.phoneNumber = phoneNumber;
	}
}