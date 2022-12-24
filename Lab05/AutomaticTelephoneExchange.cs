namespace Lab05; 

public class AutomaticTelephoneExchange {
	public string companyName { get; }
	public List<Client> clients = new List<Client>();

	public static ATEBill getBill(Client client) {
		return new ATEBill(client: client);
	}
	
	public AutomaticTelephoneExchange(string companyName) {
		this.companyName = companyName;
	}
}