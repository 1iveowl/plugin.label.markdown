﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLabelDemo
{
    public class TestHeader1Span : Span 
    {
        public TestHeader1Span()
        {
            try
            {
                SetDynamicResource(StyleProperty, "Header1StyleA");                
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
