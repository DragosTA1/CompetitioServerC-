using Model;
using Networking.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
	public class JsonProtocolUtils
	{
		public static Response CreateLoginResponse(Operator op)
		{
			Response response = new Response();
			response.Type = ResponseType.LOGIN;
			response.Operator = DTOUtils.GetDTO(op);
			return response;
		}
		public static Response CreateErrorResponse(string errorMessage)
		{
			Response response = new Response();
			response.ErrorMessage = errorMessage;
			response.Type =ResponseType.ERROR;
			return response;
		}

		public static Request CreateLoginRequest(Operator op)
		{
			Request request = new Request();
			request.Type = RequestType.LOGIN;
			request.Operator = DTOUtils.GetDTO(op);
			return request;
		}

		public static Request createGetGroupsRequest()
		{
			Request request = new Request();
			request.Type = RequestType.GET_GROUPS;
			return request;
		}

		public static Response CreateGetGroupsResponse(List<Group> groups)
		{
			Response response = new Response();
			response.Type = ResponseType.GET_GROUPS;
			response.Groups = DTOUtils.GetGroupDTOList(groups);
			return response;
		}

		internal static Request createGetContestsByGroupWithParticipationCountRequest(int idGroup)
		{
			Request request = new Request();
			request.Type = RequestType.GET_CONTESTS_AND_PARTICIPATION_COUNT_BY_GROUP;
			request.GroupID = idGroup;
			return request;
		}

		internal static Response createGetContestsByGroupWithParticipationCountResponse(List<ContestServiceDTO> contestServiceDTOs)
		{
			Response response = new Response();
			response.Type = ResponseType.GET_CONTESTS_AND_PARTICIPATION_COUNT_BY_GROUP;
			response.Contests = DTOUtils.GetContestDTOList(contestServiceDTOs);
			return response;
		}

		internal static Request createGetContestantsByContestWithParticipationCountRequest(int idContest)
		{
			Request request = new Request();
			request.Type = RequestType.GET_CONTESTANTS_AND_PARTICIPATION_COUNT_BY_CONTEST;
			request.ContestID = idContest;
			return request;
		}

		internal static Response createGetContestantsByGroupWithParticipationCountResponse(List<ContestantServiceDTO> contestantServiceDTOs)
		{
			Response response = new Response();
			response.Type = ResponseType.GET_CONTESTANTS_AND_PARTICIPATION_COUNT_BY_CONTEST;
			response.Contestants = DTOUtils.GetContestantDTOList(contestantServiceDTOs);
			return response;
		}

		internal static Request createGetGroupByAgeRequest(int age)
		{
			Request request = new Request();
			request.Type = RequestType.GET_GROUP_BY_AGE;
			request.GroupAge = age;
			return request;
		}

		public static Response createGetGroupByAgeResponse(Group group)
		{
			Response response = new Response();
			response.Type = ResponseType.GET_GROUP_BY_AGE;
			response.Groups = DTOUtils.GetGroupDTOList([group]);
			return response;
		}

		public static Request createGetContestsByGroupRequest(int idGroup)
		{
			Request request = new Request();
			request.Type = RequestType.GET_CONTESTS_BY_GROUP;
			request.GroupID = idGroup;
			return request;
		}

		public static Response CreateGetContestsByGroupResponse(List<Contest> contests)
		{
			Response response = new Response();
			response.Type = ResponseType.GET_CONTESTS_BY_GROUP;
			response.Contests = DTOUtils.GetContestDTOList(contests);
			return response;
		}

		internal static Request CreateAddContestantRequest(Contestant contestant)
		{
			Request request = new Request()
			{
				Type = RequestType.ADD_CONTESTANT,
				Contestant = DTOUtils.GetDTO(contestant)
			};
			return request;
		}

		internal static Response CreateAddContestantResponse(Contestant c)
		{
			Response response = new Response()
			{
				Type = ResponseType.ADD_CONTESTANT,
				Contestant = DTOUtils.GetDTO(c)
			};
			return response;
		}

		public static Request CreateAddParticipationRequest(Participation participation)
		{
			Request request = new Request()
			{
				Type = RequestType.ADD_PARTICIPATION,
				Participation = DTOUtils.GetDTO(participation)
			};
			return request;
		}

		public static Response CreateOkResponse()
		{
			Response response = new Response();
			response.Type = ResponseType.OK;
			return response;
		}

		public static Request CreateRegisterRequest(Operator op)
		{
			Request request = new Request();
			request.Type = RequestType.REGISTER;
			request.Operator = DTOUtils.GetDTO(op);
			return request;
		}

		public static Request CreateLogoutRequest(Operator op)
		{
			Request request = new Request();
			request.Type = RequestType.LOGOUT;
			request.Operator = DTOUtils.GetDTO(op);
			return request;
		}

		public static Response CreateParticipationAddedResponse(Participation participation)
		{
			Response response = new Response();
			response.Type = ResponseType.PARTICIPATION_NOTIFICATION;
			response.Participation = DTOUtils.GetDTO(participation);
			return response;
		}
	}
}
