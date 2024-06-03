using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
	public enum ResponseType
	{
		LOGIN, ERROR,
		GET_GROUPS,
		GET_CONTESTS_AND_PARTICIPATION_COUNT_BY_GROUP,
		GET_CONTESTANTS_AND_PARTICIPATION_COUNT_BY_CONTEST,
		GET_GROUP_BY_AGE,
		GET_CONTESTS_BY_GROUP,
		ADD_CONTESTANT,
		OK,
		PARTICIPATION_NOTIFICATION
	}
}
