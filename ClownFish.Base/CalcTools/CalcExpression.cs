using Noesis.Javascript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClownFish.Base.CalcTools
{
    /// <summary>
    /// 
    /// </summary>
    public class CalcExpression
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strCalculateExpression"></param>
        /// <returns></returns>
        public object AdvancedCalcV8(string strCalculateExpression)
        {
            if (!string.IsNullOrEmpty(strCalculateExpression))
            {
                if (strCalculateExpression.Trim().IndexOf("无") >= 0 || strCalculateExpression.Trim().IndexOf("wu") >= 0)
                    return false;
            }

            object retValue = null;

            try
            {
                return new System.Data.DataTable().Compute(strCalculateExpression, null);
            }
            catch
            {
                using (JavascriptContext ctx = new JavascriptContext())
                {
                    try
                    {
                        retValue = ctx.Run(strCalculateExpression);
                    }
                    catch (Exception ex)
                    {
                        return CheckBoolCalculate(strCalculateExpression, ex);
                    }
                }
            }


            return retValue;
        }


        private bool BoolCalculateExpression(string strCalculateExpression)
        {
            bool blRet = false;
            string[] strDatas = strCalculateExpression.Split(new char[] { '=' });
            if (strDatas != null)
            {
                string strTemp = null;

                foreach (string ss in strDatas)
                {
                    if (strTemp == null)
                    {
                        strTemp = ss.Trim();

                        continue;
                    }

                    if (!strTemp.Equals(ss.Trim()))
                    {
                        return false;
                    }
                    else
                    {

                        blRet = true;
                    }


                    strTemp = ss.Trim();
                }
            }

            return blRet;
        }




        /// <summary>
        /// 检查是否为字符串判断表达式
        /// </summary>
        /// <param name="strCalculateExpression"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        private object CheckBoolCalculate(string strCalculateExpression, Exception ex)
        {

            if (strCalculateExpression.IndexOf("=") >= 0)
            {

                if (strCalculateExpression.IndexOf("&&") >= 0 || strCalculateExpression.IndexOf("&") >= 0 || strCalculateExpression.IndexOf("||") >= 0 || strCalculateExpression.IndexOf("|") >= 0)
                {
                    bool blRet = false;

                    String[] sps = new string[] { "&&", "||", "|", "&" };

                    string[] strExpressions = strCalculateExpression.Split(sps, StringSplitOptions.RemoveEmptyEntries);

                    if (strExpressions != null)
                    {
                        foreach (string ss in strExpressions)
                        {
                            blRet = BoolCalculateExpression(ss.Trim());

                            if (!blRet)
                            {
                                return false;
                            }
                            else
                            {
                                blRet = true;
                            }
                        }
                    }

                    return blRet;
                }
                else
                {
                    return BoolCalculateExpression(strCalculateExpression);
                }

            }
            else
            {
                //找不到计算方式

                throw ex;
            }
        }


        /// <summary>
        /// 格式化值类型后小数点几位
        /// </summary>
        /// <param name="retValue"></param>
        /// <returns></returns>
        private object CalculateStringFormat(object retValue)
        {
            if (retValue != null)
            {
                if (float.TryParse(retValue.ToString(), out float fValue))
                {
                    retValue = fValue.ToString("F3");


                }
            }
            return retValue;
        }
    }

}
