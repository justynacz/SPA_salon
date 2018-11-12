namespace SPA.Server.Models
{
    public partial class WorkerRole
    {
        public int WorkerRoleId { get; set; }
        public int WorkerId { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }
        public Worker Worker { get; set; }
    }
}
