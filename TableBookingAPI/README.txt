

1. Run TableBookingAPI project as start-up project

2. Add New User in swagger UI "AddUser" section (POST request)

3. Open Postman or any other REST client

4, Create POST request " http://localhost:2082/token" with following post parameter to get bearer token

    username:[UserId]
	password:[user password]
	grant_type:password

5. Run POST request

6. Copy token from response


7. Open Swagger UI, paste token in API_KEY text box postfix by "Bearer ".
e.g.  Bearer dqv4Jv9cJ4l2nKF9m-Vl_uwXfPkH3EgBG5_XFqnz8OUI6tliNYXxIBJEwjTUptfRkx-DrcOeXKFcpWzOw3jTqq1Wa7ScHGqAK2LNlrKOqP4TtRbexV_U-eT9WuXSMnKs6Io73rZs1vOeWHro-jR54x59yZnSvLtAmapRMThKKH_oWh-avGTWpSMF7ogBNGS66q2o2BPzxcimQDoFHeIy9lwruAiehKFdR9CoT7fFzBTESg0JXVPlAK4MoVz8EEmhqj0Ftvw3GG8UKgcrB-pv12aSqHt_n5oQUd7UOWpb2aDjAGUXjrduD-2Mv79jOkbMG4JuGA2KfINESt7DDcbPaDnATAym1s3Wr5mO2Qbjcjw-pMLBys4xXmxcy_x8g6RRdm8Zqgjsy0zCIakmEayOZA

8. Click on "Explorer" button.

9. Open "Customer" section

10. Add customer booking by using POST request