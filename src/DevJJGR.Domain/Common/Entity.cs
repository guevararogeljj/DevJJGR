namespace DevJJGR.Domain.Common
{
    public abstract class Entity
    {
        public bool Visible { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public void SoftRemove()
        {
            this.Visible = false;

        }
    }
}
