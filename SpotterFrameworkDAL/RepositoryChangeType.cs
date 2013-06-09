#region File Header
/*
Copyright Rudolph Technologies .
All rights are reserved. Reproduction or transmission in whole or in part, in any form or by any means, 
electronic, mechanical or otherwise, is prohibited without the prior written consent of the copyright owner.
File Name	: RepositoryChangeType.cs
Description	: Common items used by the DAL frameowrk
Log
Date			Author			Comment
08-Jul-2012		Prince Joseph	Class created
*/
#endregion File Header

namespace Spotter.Framework.DAL
{
    /// <summary>
    /// Repository change types.
    /// </summary>
    public enum RepositoryChangeType
    {
        /// <summary>
        /// None.
        /// </summary>
        None,
        /// <summary>
        /// Get.
        /// </summary>
        Get,
        /// <summary>
        /// Add.
        /// </summary>
        Add,
        /// <summary>
        /// Update.
        /// </summary>
        Update,
        /// <summary>
        /// Delete.
        /// </summary>
        Delete
    }
}
