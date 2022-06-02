using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCourse
{
    interface ILesson
    {
        /// <summary>
        /// Код занятия
        /// </summary>
        /// 
        string Name { get; }

        /// <summary>
        /// Описание задания
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Запуск задания
        /// </summary>
        void Start();
    }
}
