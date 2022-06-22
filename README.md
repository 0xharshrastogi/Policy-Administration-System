# Policy-Administration-System

## Notes:

- **Insureity** is the Portal that allows any Agents to Login and create Policies for the consumers.
- This Portal in turn interacts with the Middleware system of the Organization which will allow the Agents to create policies based on quotes.
- **Quotes** will get generated based on the consumer business. A quote is an estimate of premium for the insurance coverage you selected and information you entered.

## Scope

---

- ### Consumer/Customer

  - Consumer is the customer here who wishes to subscribe to a Business Property. Insurance
  - The **Consumer Microservice** has to interact with **Policy Microservice** to create a policy and as well as to view the policy status

  #### Action and Routes

  | Action                   | Method | Route                                |
  | ------------------------ | ------ | ------------------------------------ |
  | Create Consumer Business | POST   | /createConsumerBusiness              |
  | View Consumer Business   | GET    | /viewConsumerBusiness/{customerId}   |
  | Update Consumer Business | PUT    | /updateConsumerBusiness/{customerId} |
  | Create Business Property | POST   | /createBusinessProperty              |

  #### MODEL

  | Property         | Entity Type | SQL Type                    | Tags | Validation                                                 |
  | ---------------- | ----------- | --------------------------- | ---- | ---------------------------------------------------------- |
  | Id               | Guid        |                             |      |                                                            |
  | Name             | String      | NVARCHAR(100)               |      | **MINLENGTH**=3, **MAXLENGTH** = 100                       |
  | Email            | String      | NVARCHAR(100)               |      | **MINLENGTH**=3, **MAXLENGTH** = 100, **Check your Email** |
  | DateOfBirth      | DateTime    | -                           |      | DateOfBirth must be before present time                    |
  | PAN              | String      | NVARCHAR(NoOfCharInPanCard) |      | Validate For Pancard                                       |
  | BusinessTurnOver | decimal     |                             |      | Buisness turnover must be greater and equals to zero       |
  | TotalEmployees   | int         |                             |      | Total Employee must be greater and equals to zero          |
  | AgentId          | Guid        |                             |      |                                                            |
  | Agent            | Agent       |                             |      |                                                            |

---

### Business Property

- Consumer is the customer here who wishes to subscribe to a Business Property Insurance

  #### Action and Routes

  | Action                   | Method | Route                                |
  | ------------------------ | ------ | ------------------------------------ |
  | Create Business Property | POST   | /createConsumerBusiness              |
  | View Business Property   | GET    | /viewConsumerBusiness/{customerId}   |
  | Update Business Property | PUT    | /updateConsumerBusiness/{customerId} |

  #### MODEL

  | Property         | Entity Type | SQL Type                    | Tags | Validation                                           |
  | ---------------- | ----------- | --------------------------- | ---- | ---------------------------------------------------- |
  | Id               | Guid        |                             |      |                                                      |
  | BusinessId       | Guid        |                             |      | Must be a valid BusinessID                           |
  | Type             | float       | NVARCHAR(100)               |      | Must be greater than 0                               |
  | DateOfBirth      | DateTime    | -                           |      | DateOfBirth must be before present time              |
  | PAN              | String      | NVARCHAR(NoOfCharInPanCard) |      | Validate For Pancard                                 |
  | BusinessTurnOver | decimal     |                             |      | Buisness turnover must be greater and equals to zero |
  | TotalEmployees   | int         |                             |      | Total Employee must be greater and equals to zero    |
  | AgentId          | Guid        |                             |      |                                                      |
  | Agent            | Agent       |                             |      |                                                      |
