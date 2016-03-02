﻿module Account

open Orleankka.FSharp

type AccountMessage = 
   | Balance
   | Deposit of int
   | Withdraw of int 
   
type Account() = 
   inherit Actor<AccountMessage>()

   let mutable balance = 0   
   
   override this.Receive(message, reply) = task {
      match message with
      | Balance         -> balance |> reply
      | Deposit amount  -> balance <- balance + amount
      | Withdraw amount -> 
          if balance >= amount then balance <- balance - amount         
          else invalidOp "Amount may not be larger than account balance. \n"
   }
