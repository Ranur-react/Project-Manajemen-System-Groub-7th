using API.Context;
using API.Models;
using API.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class ProgressRepository : GeneralRepository<MyContext, Progress, int>
    {
        private readonly MyContext myContext;
        public ProgressRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public int RequestRequirement(FormProgress progress) //use postman  to test
        {

            try
            {
                var prgsts = progress.ProgressStatus + 1;

                var prg = new Progress
                {
                    Name = progress.Name,
                    DateEntry = DateTime.Now,
                    ColorCode = progress.ColorCode,
                    ProgresDetails = progress.ProgresDetails,
                    Approver = progress.Approver,
                    ProgressStatus = prgsts,


                };
                myContext.Progresses.Add(prg);
                myContext.SaveChanges();

                var prghistory = new ProjectHistory
                {
                    IdProgres = prg.Id,
                    IdProject = progress.IdProject

                };
                myContext.ProjectHistorys.Add(prghistory);
                myContext.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }



    }
}
   

