# 哲学与社会科学规划项目信息化管理平台
[![](https://img.shields.io/badge/%E4%B8%BB%E9%A1%B5-%E5%93%B2%E5%AD%A6%E4%B8%8E%E7%A4%BE%E4%BC%9A%E7%A7%91%E5%AD%A6%E8%A7%84%E5%88%92%E9%A1%B9%E7%9B%AE%E4%BF%A1%E6%81%AF%E5%8C%96%E7%AE%A1%E7%90%86%E5%B9%B3%E5%8F%B0-brightgreen
)](https://github.com/03xiaoyuhe/firstProgram/)

项目参与者？
[![](https://img.shields.io/badge/%E7%AB%8B%E5%88%BB%E6%9F%A5%E7%9C%8B-%E9%A1%B9%E7%9B%AE%E5%AE%89%E6%8E%92%E4%BF%A1%E6%81%AF%E5%8F%91%E5%B8%83-red
)](https://github.com/03xiaoyuhe/firstProgram/issues/1)





## 目录

- [背景](#背景)
- [安排](#安装)
- [用法](#用法)
  - [关于数据表的建立](#关于数据库字段建立)

## 背景



## 安装



## 用法



### 关于数据库字段建立

> ### 目录
>
> - [关于数据表的建立](#关于数据库字段建立)
>   - [符号说明](#符号说明)
>   - [项目信息表  `Projects`](#项目信息表)
>   - [项目立项申请表 (`ProjectProposals`)](#项目立项申请表)
>   - [项目修改申请表 (`ProjectModifications`)](#项目修改申请表)
>   - [项目结项申请表 (`ProjectClosures`)](#项目结项申请表)
>   - [审批历史表 (`ApprovalHistory`)](#审批历史表)
>   - [申请小队表 (`ApplicationTeams`)](#申请小队表)
>   - [小队成员表 (`TeamMembers`)](#小队成员表)
>   - [用户表 (`Users`)](#用户表)



#### 符号说明

> 字段名右标 `*` 为主键
>
> 字段名右标 `^` 为外键



#### 项目信息表
#### `Projects`

| 字段名            | 内容         | 类型 | 属性 |
| ----------------- | ------------ | ---- | ---- |
| `ProjectID`       | 项目ID /编号 |      | 主键 |
| `ProjectName`     | 项目名称     |      |      |
| `Description`     | 课题名称     |      |      |
| `ProjectManager`  | 项目负责人   |      |      |
| `Phone number`    | 联系方式     |      |      |
| `Pjtcategory`     | 项目负责人   |      |      |
| `Sjtclassify`     | 项目类别     |      |      |
| `ApplicationDate` | 申请日期     |      |      |



#### 项目立项申请表
#### `ProjectProposals`

| 字段名            | 内容     | 类型 | 属性 |
| ----------------- | -------- | ---- | ---- |
| `ProposalID ` *   | 申请ID   |      | 主键 |
| `ProjectID` ^     | 项目ID   |      | 外键 |
| `Applicant`       | 申请人   |      |      |
| `ApplicationDate` | 申请日期 |      |      |
| `ApprovalStatus`  | 审批状态 |      |      |



#### 项目修改申请表
#### `ProjectModifications`

| 字段名              | 内容       | 属性 | 类型 |
| ------------------- | ---------- | ---- | ---- |
| `ModificationID ` * | 修改申请ID | 主键 |      |
| `ProjectID`         | 项目ID     | 外键 |      |
| `Applicant`         | 申请人     |      |      |
| `ApplicationDate`   | 申请日期   |      |      |
| `Description`       | 修改描述   |      |      |
| `ApprovalStatus`    | 审批状态   |      |      |



#### 项目结项申请表
#### `ProjectClosures`

| 字段名            | 内容       | 属性                   | 类型 |
| ----------------- | ---------- | ---------------------- | ---- |
| `ClosureID ` *    | 结项申请ID | 主键                   |      |
| `ProjectID` ^     | 项目ID     | 外键，关联到项目信息表 |      |
| `Applicant`       | 申请人     |                        |      |
| `ApplicationDate` | 申请日期   |                        |      |
| `ClosureReason`   | 结项原因   |                        |      |
| `ApprovalStatus`  | 审批状态   |                        |      |



#### 审批历史表
#### `ApprovalHistory`

| 字段名                                    | 内容     | 属性                     | 类型 |
| ----------------------------------------- | -------- | ------------------------ | ---- |
| `RecordID` *                              | 记录ID   | 主键                     |      |
| `ProposalID`/`ModificationID`/`ClosureID` | 申请ID   | 外键，关联到对应的申请表 |      |
| `Approver`                                | 审批人   |                          |      |
| `ApprovalDate`                            | 审批日期 |                          |      |
| `ApprovalComments`                        | 审批意见 |                          |      |



#### 申请小队表
#### `ApplicationTeams`

| 字段名         | 内容     | 属性 | 类型 |
| -------------- | -------- | ---- | ---- |
| `RecordID` *   | 记录ID   | 主键 |      |
| `TeamName`     | 小队名称 |      |      |
| `TeamLeader`   | 负责人   |      |      |
| `CreationDate` | 创建日期 |      |      |

 

#### 小队成员表
#### `TeamMembers`

| 字段名       | 内容     | 属性                                      | 类型 |
| ------------ | -------- | ----------------------------------------- | ---- |
| `RecordID` * | 记录ID   | 主键                                      |      |
| `TeamID`     | 小队ID   | 外键，关联到申请小队表                    |      |
| `MemberID`   | 成员ID   | 外键，关联到用户表 (如果需要记录成员信息) |      |
| `MemberRole` | 成员角色 |                                           |      |
| `JoinDate`   | 加入日期 |                                           |      |

 

#### 用户表
#### `Users`

| 字段名        | 内容     | 属性 | 类型 |
| ------------- | -------- | ---- | ---- |
| `UserID` *    | 用户ID   | 主键 |      |
| `Username`    | 用户名   |      |      |
| `Password`    | 密码     |      |      |
| `FullName`    | 姓名     |      |      |
| `identity`    | 身份     |      |      |
| `ContactInfo` | 联系信息 |      |      |





## 相关项目

暂无



## 主要项目负责人

[@03xiaoyuhe](https://github.com/03xiaoyuhe)



## 参与贡献方式



### 贡献人员

[@03xiaoyuhe](https://github.com/03xiaoyuhe)
[@xxxlzm](https://github.com/xxxlzm)

感谢所有贡献的人。

