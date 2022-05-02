using Microsoft.AspNetCore.Mvc;
using Model;

namespace AppLogic.datesLogic;

public class datesLogic
{
    static datesDAO service = new datesDAO();

    public static void suggestPlan(string email_send, string email_recieve)
    {
        //TODO
        return;
    }

    public static void acceptPlan(string email_send, string email_recieve)
    {
        //TODO
        return;
    }

    public async static Task<PlanVO> getDefaultPlan()
    {
        return await service.getDefaultPlan();
    }

    public static void acceptFecha(string email_send, string email_recieve)
    {
        //TODO
        return;
    }

    public static void suggestFecha(string email_send, string email_recieve, string moment)
    {
        //TODO
        return;
    }

    public static void checkStatus(string email1, string email2)
    {
        //TODO
        return;
    }
}