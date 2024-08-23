namespace Models.PageDataSor.ErroMassage
{
    public class LineAbsentOrUnValidErro : ErroBase
    {
        string lineName;
        public string LineName
        {
            get
            {
                return lineName;
            }
            set
            {
                lineName = value;
            }
        }
    }
}
