namespace SoccerPitch.Models;

public class FormationSlot
{
    int FormationSlotId { get; set; }
    string PositionCode { get; set; }
    decimal xPosition  { get; set; }
    decimal yPosition { get; set; }
    int FormationId { get; set; }
    Formation Formation { get; set; }
}