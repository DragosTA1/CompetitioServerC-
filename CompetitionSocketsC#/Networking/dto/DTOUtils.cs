using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking.dto
{
	public class DTOUtils
	{
		public static Operator GetFromDTO(OperatorDTO operatorDTO)
		{
			Operator dtoOp = operatorDTO.Operator;

			Operator op = new Operator(dtoOp.Username, dtoOp.Password, dtoOp.Email, dtoOp.City)
			{
				Id = dtoOp.Id
			};

			return op;
		}

		public static OperatorDTO GetDTO(Operator op)
		{
			OperatorDTO operatorDTO = new OperatorDTO(op);
			return operatorDTO;
		}

		public static List<Group> GetGroupListFromDTO(List<GroupDTO> groupsDTOS)
		{
			List<Group> groups = new();
            foreach (var grDTO in groupsDTOS)
            {
				if (grDTO.group is null)
				{
					groups.Add(new Group());
				}
				else
				{
					Group gr = new Group(grDTO.group.MinimumAge, grDTO.group.MaximumAge);
					gr.Id = grDTO.group.Id;
					groups.Add(gr);
				}
            }
			return groups;
        }

		public static List<GroupDTO> GetGroupDTOList(List<Group> groups)
		{
			List<GroupDTO> groupDTOS = new();
            foreach (var gr in groups)
            {
				groupDTOS.Add(new GroupDTO(gr));
            }
			return groupDTOS;
        }

		public static List<ContestServiceDTO> GetContestServiceDTOListFromDTO(List<ContestDTO> contestDTOS)
		{
			List<ContestServiceDTO> contestServiceDTOs = new List<ContestServiceDTO>();
            foreach (var cntDTO in contestDTOS)
            {
				ContestServiceDTO contestServiceDTO = cntDTO.ContestServiceDTO;
				contestServiceDTOs.Add(contestServiceDTO);
            }
			return contestServiceDTOs;
        }

		public static List<ContestDTO> GetContestDTOList(List<ContestServiceDTO> contestServiceDTOs)
		{
			List<ContestDTO> contestDTOs = new List<ContestDTO>();
			foreach (var cntServDTO in contestServiceDTOs)
			{
				ContestDTO contestDTO = new ContestDTO(cntServDTO);
				contestDTOs.Add (contestDTO);
			}
			return contestDTOs;
		}

		internal static List<ContestantServiceDTO> GetContestantServiceDTOListFromDTO(List<ContestantDTO> contestantDTOS)
		{
			List<ContestantServiceDTO> contestantServiceDTOs = new List<ContestantServiceDTO>();
			foreach (var contestantDTO in contestantDTOS)
			{
				ContestantServiceDTO contestantServiceDTO = contestantDTO.ContestantServiceDTO;
				contestantServiceDTOs.Add(contestantServiceDTO);
			}
			return contestantServiceDTOs;
		}

		public static List<ContestantDTO> GetContestantDTOList(List<ContestantServiceDTO> contestantServiceDTOs)
		{
			List<ContestantDTO> contestantDTOs = new List<ContestantDTO>();
			foreach ( var contestantServDTO in contestantServiceDTOs)
			{
				ContestantDTO contestantDTO = new ContestantDTO(contestantServDTO);
				contestantDTOs.Add(contestantDTO);
			}
			return contestantDTOs;
		}

		public static List<Contest> GetContestListFromDTO(List<ContestDTO> contestsDTO)
		{
			List<Contest> contests = new List<Contest>();
            foreach (var contestDTO in contestsDTO)
            {
				Contest contest = new Contest(contestDTO.ContestServiceDTO.Type, contestDTO.ContestServiceDTO.ParentGroup)
				{
					Id = contestDTO.ContestServiceDTO.Id,
				};
				contests.Add(contest);
            }
			return contests;
        }

		public static List<ContestDTO> GetContestDTOList(List<Contest> contests)
		{
			List<ContestDTO> contestDTOs = new List<ContestDTO>();
            foreach (var cnt in contests)
            {
				ContestDTO contestDTO = new ContestDTO(cnt, 0);
				contestDTOs.Add(contestDTO);
            }
			return contestDTOs;
        }

		internal static ContestantDTO GetDTO(Contestant contestant)
		{
			ContestantDTO contestantDTO = new ContestantDTO(contestant, 0);
			return contestantDTO;
		}

		internal static Contestant GetFromDTO(ContestantDTO contestantDTO)
		{
			Contestant contestant = new Contestant(contestantDTO.ContestantServiceDTO.Name, contestantDTO.ContestantServiceDTO.Age, contestantDTO.ContestantServiceDTO.CNP)
			{
				Id = contestantDTO.ContestantServiceDTO.Id
			};
			return contestant;
		}

		public static ParticipationDTO GetDTO(Participation participation)
		{
			ParticipationDTO participationDTO = new ParticipationDTO(participation.Contestant, participation.Contest, participation.Date);
			return participationDTO;
		}

		internal static Participation GetFromDTO(ParticipationDTO participationDTO)
		{
			DateTime date = DateTime.Parse(participationDTO.DateString);
			Participation participation = new Participation(participationDTO.Contest, participationDTO.Contestant, date)
			{
				Id = participationDTO.Id
			};
			return participation;
		}
	}
}
