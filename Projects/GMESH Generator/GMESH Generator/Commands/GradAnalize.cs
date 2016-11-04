using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Analyzer.Grade;
using Analyzer;

namespace GMESH_Generator.Commands
{
    public class GradAnalize: ICommand
    {
        private Buffer storage;
        private IGrade grade = new ArithmMeanGrade();
        private GMESHFileStream.IWriter writer = new GMESHFileStream.OBJFile.OBJCreator();

        private double estimate;
        public double Estimate
        {
            get { return estimate; }
        }

        public GradAnalize()
        {
            storage = Buffer.getInstance();
        }

        public void callBack()
        {
            if (storage.Meshs == null || storage.PathSave == null)   //проверяем, есть ли что сохранять, и есть ли куда сохранять
                return;

            estimate = grade.calculate(storage.Meshs[0]);
        }
    }
}
