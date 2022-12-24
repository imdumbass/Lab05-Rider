namespace Lab05; 

public class Call {
	public UInt32 callDuration { get; set; }	/* Длительность звонка в секундах */
	public string number { get; }				/* Номер телефона */
	public bool isOutgoing { get; }				/* Является ли звонок исходящим */
	public DateTime startDate { get; }					/* Дата начала звонка */
	
	public Call(UInt32 callDuration, string number, bool isOutgoing, DateTime startDate) {
		this.callDuration = callDuration;
		this.number = number;
		this.isOutgoing = isOutgoing;
		this.startDate = startDate;
	}
}