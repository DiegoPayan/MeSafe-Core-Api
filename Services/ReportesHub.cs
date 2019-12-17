using System.Threading.Tasks;
using Backend.DTO;
using Backend.Models;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Services
{
  public class ReportesHub : Hub
  {
    public async Task newEmergencyReport(ReporteHubRequestDto report)
    {
      if (report != null)
      {
        await Clients.All.SendAsync("newReport", report);
      }
    }
  }
}