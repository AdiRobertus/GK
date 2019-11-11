using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK
{
    interface ICrud<T>
    {
        T Data { get; set; }
        bool IsInserting { get; set; }
        void SaveData();
        void LoadData();
        void NormalMode();
        void SaveMode();
        bool IsValid();
    }
}
