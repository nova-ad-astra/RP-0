using ContractConfigurator.Parameters;

namespace ContractConfigurator.RP0
{
    public class MachVesselParam : VesselParameter
    {
        protected double mach;

        public MachVesselParam() : base(null) { }

        public MachVesselParam(string title, double mach) : base(title)
        {
            this.mach = mach;
            this.title = GetParameterTitle();
        }

        protected override void OnParameterSave(ConfigNode node)
        {
            base.OnParameterSave(node);

            node.AddValue("mach", mach);
        }

        protected override void OnParameterLoad(ConfigNode node)
        {
            base.OnParameterLoad(node);

            node.TryGetValue("mach", ref mach);
        }

        protected override string GetParameterTitle()
        {
            return $"Reach mach {mach:0.##}";
        }

        protected override bool VesselMeetsCondition(Vessel vessel)
        {
            return FlightGlobals.ActiveVessel?.mach > mach;
        }
    }
}
