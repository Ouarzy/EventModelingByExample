module Banking.Domain.BankAccount

type Euro = decimal

type State = { Solde: Euro}
let initial = {
    Solde = 0m
}

let private apply (state: State) = function
    | _ -> state

let private applyAll history =
    history |> Seq.fold apply initial

let credit date amount history =
    failwith "test"
    []