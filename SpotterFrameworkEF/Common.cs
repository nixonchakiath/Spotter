#region File Header
/*
Copyright Rudolph Technologies .
All rights are reserved. Reproduction or transmission in whole or in part, in any form or by any means, 
electronic, mechanical or otherwise, is prohibited without the prior written consent of the copyright owner.
File Name	: Common.cs
Description	: This class contains the common types used by data access layers
Log
Date			Author			Comment
12-Jun-2012		Prince Joseph	Class created

*/
#endregion File Header

namespace RTEC.Framework.EF
{
    /// <summary>
    /// This class contains the common types used by data access layers
    /// </summary>
    public class Common
    {
        /// <summary>
        /// Represents the Type of the tool
        /// </summary>
        public enum ToolType
        {
            MetaPulse,
            Transparent
        }
    }
}
